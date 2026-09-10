using PlushieChaosSquad.Helpers;
using PlushieChaosSquad.Interfaces;
using PlushieChaosSquad.Libraries;
using PlushieChaosSquad.Models.Incidents;
using PlushieChaosSquad.Models.Moves;
using PlushieChaosSquad.Models.Squad;
using System.Diagnostics;
using static System.Collections.Specialized.BitVector32;

namespace PlushieChaosSquad.Services
{
    internal class DispatchCenter
    {
        private readonly object _dispatchLock = new object();


        private readonly List<Plushie> _plushies = PlushieLibrary.GetAllPlushies();
        private readonly List<ChaosIncident> _incidents = new List<ChaosIncident>();


        /// <summary>
        /// Registers a plushie with the dispatch center.
        /// </summary>
        /// <param name="plushie">The plushie to register.</param>
        internal void RegisterPlushie(Plushie plushie)
        {
            if (plushie == null) return;
            _plushies.Add(plushie);
        }



        /// <summary>
        /// Adds a chaos incident to the dispatch center.
        /// </summary>
        /// <param name="incident">The chaos incident to add.</param>
        internal void AddIncident(ChaosIncident incident)
        {
            if (incident == null) return;
            _incidents.Add(incident);
        }

        internal Plushie DispatchPlushie(
            ChaosIncident incident,
            IDispatchStrategy strategy)
        {
            lock (_dispatchLock)
            {
                List<Plushie> availablePlushies = _plushies
                    .Where(plushie => plushie.IsAvailable)
                    .ToList();

                Plushie plushie = strategy.SelectPlushie(
                    incident,
                    availablePlushies);

                plushie.MarkAsBusy();

                return plushie;
            }
        }


        /// <summary>
        /// Resolves a chaos incident using the specified action.
        /// </summary>
        /// <param name="incident">The incident to resolve.</param>
        /// <param name="action">The action used to resolve the incident.</param>
        internal void ResolveIncident(
            ChaosIncident incident,
            Action<ChaosIncident> action)
        {
            action(incident);
        }

        internal string HandleIncident(
        ChaosIncident incident,
        IDispatchStrategy strategy,
        Action<ChaosIncident> onResolved)
        {
            Plushie plushie = DispatchPlushie(
                incident,
                strategy);

            string report = HandleChaosByLevel(
                plushie,
                incident.ChaosLevel,
                out bool handled);

            if (handled)
            {
                ResolveIncident(
                    incident,
                    onResolved);
            }

            plushie.MarkAsAvailable();

            return report;
        }

        internal async Task<List<string>> HandleIncidentsAsync(
            IDispatchStrategy strategy,
            Action<ChaosIncident> onResolved)
        {
            List<Task<string>> tasks = _incidents
                .Where(incident => !incident.IsResolved)
                .Select(incident =>
                    Task.Run(() =>
                        HandleIncident(
                            incident,
                            strategy,
                            onResolved)))
                .ToList();

            return (await Task.WhenAll(tasks)).ToList();
        }

        private string HandleChaosByLevel(

            Plushie plushie,
            ChaosLevel chaosLevel,
            out bool handled)
        {
            return chaosLevel switch
            {
                ChaosLevel.Low => HandleLowIncident(plushie, out handled),
                ChaosLevel.Medium => HandleMediumIncident(plushie, out handled),
                ChaosLevel.High => HandleHighIncident(plushie, out handled),
                _ => throw new UnreachableException()
            };
        }
        private string HandleLowIncident(
            Plushie plushie,
            out bool handled)
        {
            ChaosMove move = plushie.MakeChaos();

            string availabilityReport =
                CheckAndHandleAvailability(plushie, move, out handled);

            if (!handled)
            {
                return availabilityReport;
            }

            string report =
                $"{plushie.Name} {move.Success}\n";

            report += plushie.UseEnergy(move.EnergyCost, move.Name);

            return report;
        }

        private string HandleMediumIncident(
            Plushie plushie,
            out bool handled)
        {
            ChaosSession session = new ChaosSession();
            string report = "";

            handled = true;

            for (int i = 0; i < 2; i++)
            {
                ChaosMove move = plushie.MakeChaos();

                string availabilityReport =
                    CheckAndHandleAvailability(plushie, move, out bool available);

                if (!available)
                {
                    return availabilityReport;
                }

                report += ExecuteSessionMove(
                    plushie,
                    move,
                    session);
            }

            return report;
        }

        private string HandleHighIncident(
            Plushie plushie,
            out bool handled)
        {
            ChaosSession session= new ChaosSession();
            handled = true;
                            
            string report =
                $"{plushie.PerformSignatureChaos()}\n";
            session.RegisterSignature(plushie);

            ChaosMove move = plushie.MakeChaos();

            string availabilityReport =
                CheckAndHandleAvailability(plushie, move, out handled);

            if (!handled)
            {
                return availabilityReport;
            }

            report +=
                $"{plushie.Name} {move.Success}\n";

            report += plushie.UseEnergy(move.EnergyCost, move.Name);

            return report;
        }

        private string CheckAndHandleAvailability(
            Plushie plushie,
            ChaosMove move,
            out bool handled)
        {
            (bool isAvailable, string message) =
                plushie.CheckAvailability();

            if (!isAvailable)
            {
                handled = false;

                return
                    $"{plushie.Name} was supposed to {move.Intent} But {message}\n";
            }

            handled = true;
            return "";
        }

        private string ExecuteSessionMove(
            Plushie plushie,
            ChaosMove move,
            ChaosSession session)
        {
            if (!session.HasBeenUsed(move))
            {
                session.RegisterMove(move);

                string report =
                    $"{plushie.Name} {move.Success}\n";

                report += plushie.UseEnergy(move.EnergyCost, move.Name);

                return report;
            }

            string failureReport =
                $"{plushie.Name} was supposed to {move.Intent}, " +
                $"{move.Failure}\n";

            ChaoticFailureMove failureMove =
                ChaoticFailureMoveLibrary.GetRandomFailureMove();

            failureReport +=
                $"{plushie.Name} {failureMove.Execute()}\n";

            failureReport +=
                plushie.UseEnergy(failureMove.EnergyCost, failureMove.Name);

            return failureReport;
        }
        internal async Task WreakHavoc()
        {
            List<Plushie> availablePlushies = _plushies
                .Where(plushie => plushie.IsAvailable)
                .ToList();

            ChaosSession session = new ChaosSession();

            UIHelpers.WriteBlue("WREAK HAVOC");

            bool stillHasEnergy = true;

            while (stillHasEnergy)
            {
                stillHasEnergy = false;

                foreach (Plushie plushie in availablePlushies)
                {
                    if (plushie.ChaosEnergy <= 0)
                    {
                        continue;
                    }

                    stillHasEnergy = true;

                    ChaosMove move = plushie.MakeChaos();

                    string result;

                    if (!session.HasBeenUsed(move))
                    {
                        result =
                            $"{plushie.Name} {move.Execute()}\n" +
                            plushie.UseEnergy(move.EnergyCost, move.Name);

                        session.RegisterMove(move);
                    }
                    else
                    {
                        ChaoticFailureMove failureMove =
                            ChaoticFailureMoveLibrary.GetRandomFailureMove();

                        result =
                            $"{plushie.Name} {DeclareIntent()} " +
                            $"{move.Intent.TrimEnd('.')}. {DeclareObjection()} " +
                            $"{move.Failure}\n" +
                            $"{failureMove.Execute()}\n" +
                            plushie.UseEnergy(failureMove.EnergyCost, move.Name);

                    }

                    Console.WriteLine(result.Trim());
                    Console.WriteLine();

                    await Task.Delay(400);
                }
            }


        }
        private readonly Random random = new Random();
        private string DeclareObjection()
        {
            return objections[random.Next(objections.Length)];
        }
        private string[] objections = [
            "However,",
            "But",
            "Heartbreakingly,",
            "Unfortunately,",
            "Regrettably,",
            "Sadly,",
            "Allegedly,",
            "Seemingly,"];
        private string DeclareIntent()
        {
            return preIntent[random.Next(preIntent.Length)];

        }
        private string[] preIntent = [
            "set out to",
        "was going to",
        "wanted to",
        "planned to",
        "tried to",
        "intended to",
        "was supposed to",
        "attempted to"];
    }
}