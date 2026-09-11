using PlushieChaosSquad.Helpers;
using PlushieChaosSquad.Interfaces;
using PlushieChaosSquad.Libraries;
using PlushieChaosSquad.Models.Incidents;
using PlushieChaosSquad.Models.Moves;
using PlushieChaosSquad.Models.Squad;
using System.Diagnostics;

namespace PlushieChaosSquad.Services
{
    /// <summary>
    /// Coordinates the dispatch of plushies to chaos incidents and manages
    /// the execution and resolution of those incidents.
    /// </summary>
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

        /// <summary>
        /// Selects an available plushie using the specified dispatch strategy
        /// and marks the selected plushie as busy.
        /// </summary>
        /// <param name="incident">
        /// The chaos incident that requires a plushie.
        /// </param>
        /// <param name="strategy">
        /// The strategy used to select a suitable plushie.
        /// </param>
        /// <returns>
        /// The plushie selected to handle the incident.
        /// </returns>
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
        /// Resolves a chaos incident by executing the specified resolution action.
        /// </summary>
        /// <param name="incident">The incident to resolve.</param>
        /// <param name="action">The action to execute when resolving the incident.</param>
        internal void ResolveIncident(
            ChaosIncident incident,
            Action<ChaosIncident> action)
        {
            action(incident);
        }
        /// <summary>
        /// Dispatches a plushie to handle a chaos incident, executes the
        /// appropriate chaos behavior, and resolves the incident if it was handled.
        /// </summary>
        /// <param name="incident">
        /// The chaos incident to handle.
        /// </param>
        /// <param name="strategy">
        /// The strategy used to select a plushie for the incident.
        /// </param>
        /// <param name="onResolved">
        /// The action to execute when the incident is successfully resolved.
        /// </param>
        /// <returns>
        /// A textual report describing how the incident was handled.
        /// </returns>
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

        /// <summary>
        /// Asynchronously handles all unresolved chaos incidents using the
        /// specified dispatch strategy.
        /// </summary>
        /// <param name="strategy">
        /// The strategy used to select plushies for the incidents.
        /// </param>
        /// <param name="onResolved">
        /// The action to execute when an incident is successfully resolved.
        /// </param>
        /// <returns>
        /// A task containing a list of reports generated for the handled incidents.
        /// </returns>
        internal async Task<List<string>> HandleAllIncidentsAsync(
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

        /// <summary>
        /// Selects the appropriate chaos handling method based on the incident's
        /// chaos level.
        /// </summary>
        /// <param name="plushie">
        /// The plushie handling the incident.
        /// </param>
        /// <param name="chaosLevel">
        /// The severity level of the chaos incident.
        /// </param>
        /// <param name="handled">
        /// Indicates whether the incident was successfully handled.
        /// </param>
        /// <returns>
        /// A textual report describing the result of the chaos handling.
        /// </returns>
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

        /// <summary>
        /// Handles a low-level chaos incident by performing one chaos move.
        /// </summary>
        /// <param name="plushie">
        /// The plushie performing the chaos move.
        /// </param>
        /// <param name="handled">
        /// Indicates whether the incident was successfully handled.
        /// </param>
        /// <returns>
        /// A textual report describing the performed move and its energy cost,
        /// or an availability message if the move could not be performed.
        /// </returns>
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

        /// <summary>
        /// Handles a medium-level chaos incident by attempting two chaos moves.
        /// </summary>
        /// <param name="plushie">
        /// The plushie performing the chaos moves.
        /// </param>
        /// <param name="handled">
        /// Indicates whether the incident was successfully handled.
        /// </param>
        /// <returns>
        /// A textual report describing the performed moves.
        /// </returns>
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

        /// <summary>
        /// Handles a high-level chaos incident by performing a signature chaos
        /// action followed by an additional chaos move.
        /// </summary>
        /// <param name="plushie">
        /// The plushie performing the chaos actions.
        /// </param>
        /// <param name="handled">
        /// Indicates whether the incident was successfully handled.
        /// </param>
        /// <returns>
        /// A textual report describing the performed chaos actions.
        /// </returns>
        private string HandleHighIncident(
            Plushie plushie,
            out bool handled)
        {
            ChaosSession session = new ChaosSession();
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


        /// <summary>
        /// Checks whether a plushie is able to perform a chaos move.
        /// </summary>
        /// <param name="plushie">
        /// The plushie attempting to perform the move.
        /// </param>
        /// <param name="move">
        /// The chaos move the plushie is attempting to perform.
        /// </param>
        /// <param name="handled">
        /// Indicates whether the move can be performed.
        /// </param>
        /// <returns>
        /// An availability message if the plushie cannot perform the move;
        /// otherwise, an empty string.
        /// </returns>
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
                    $"{plushie.Name} {DeclareIntent()} {move.Intent} {DeclareObjection()} {message}\n";
            }

            handled = true;
            return "";
        }

        /// <summary>
        /// Executes a chaos move within the current chaos session.
        /// If the move has already been used during the session, a chaotic
        /// failure move is performed instead.
        /// </summary>
        /// <param name="plushie">
        /// The plushie performing the move.
        /// </param>
        /// <param name="move">
        /// The chaos move to execute.
        /// </param>
        /// <param name="session">
        /// The chaos session tracking previously used moves.
        /// </param>
        /// <returns>
        /// A textual report describing the result of the move.
        /// </returns>
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
                $"{plushie.Name} {DeclareObjection()} {move.Intent}. " +
                $"{DeclareObjection()} {move.Failure}\n";

            ChaoticFailureMove failureMove =
                ChaoticFailureMoveLibrary.GetRandomFailureMove();

            failureReport +=
                $"{plushie.Name} {failureMove.Execute()}\n";

            failureReport +=
                plushie.UseEnergy(failureMove.EnergyCost, failureMove.Name);

            return failureReport;
        }

        /// <summary>
        /// Continuously performs chaos moves with all currently available
        /// plushies until none of them have any chaos energy remaining.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous havoc sequence.
        /// </returns>
        internal async Task WreakHavocAsync()
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

                    await Task.Delay(800);
                }
            }
        }
        //private readonly Random random = new Random();

        /// <summary>
        /// Selects a random objection phrase used when describing failed
        /// or interrupted chaos actions.
        /// </summary>
        /// <returns>
        /// A randomly selected objection phrase like "However," or "But".
        /// </returns>
        private string DeclareObjection()
        {
        Random random = new Random();

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

        /// <summary>
        /// Selects a random phrase used to introduce a plushie's intended action.
        /// </summary>
        /// <returns>
        /// A randomly selected intent phrase.
        /// </returns>
        private string DeclareIntent()
        {
        Random random = new Random();

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