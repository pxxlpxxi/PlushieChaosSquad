using PlushieChaosSquad.Interfaces;
using PlushieChaosSquad.Libraries;
using PlushieChaosSquad.Models.Incidents;
using PlushieChaosSquad.Models.Moves;
using PlushieChaosSquad.Models.Squad;

namespace PlushieChaosSquad.Services
{
    /// <summary>
    ///
    /// </summary>
    internal class DispatchCenter
    {
        private readonly List<Plushie> _plushies = PlushieLibrary.GetAllPlushies();
        //private readonly List<IDispatchStrategy> _strategies = new List<IDispatchStrategy>();
        private readonly List<ChaosIncident> _incidents = new List<ChaosIncident>();

        /// <summary>
        /// Creates a new dispatch center using the specified dispatch strategy.
        /// </summary>
        //internal DispatchCenter(IDispatchStrategy strategy) => _strategies.Add(strategy);

        /// <summary>
        /// Registers a plushie with the dispatch center.
        /// </summary>
        /// <param name="plushie">The plushie to register.</param>
        internal void RegisterPlushie(Plushie plushie)
        {
            if (plushie == null) return;
            _plushies.Add(plushie);
        }

        ///// <summary>
        ///// Registers a strategy with the dispatch center.
        ///// </summary>
        ///// <param name="strategy">The dispatch center strategy to register</param>
        //internal void RegisterStrategy(IDispatchStrategy strategy)
        //{
        //    if (strategy == null) return;
        //    _strategies.Add(strategy);
        //}



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
        /// Dispatches a plushie to handle a chaos incident using the specified strategy.
        /// </summary>
        /// <param name="incident">The chaos incident that needs to be handled.</param>
        /// <param name="strategy">The strategy used to select a plushie.</param>
        /// <returns>The plushie selevted to handle the incident.</returns>
        internal Plushie DispatchPlushie(
            ChaosIncident incident,
            IDispatchStrategy strategy)
        {
            List<Plushie> availablePlushies = _plushies
                .Where(plushie => plushie.IsAvailable)
                .ToList();

            return strategy.SelectPlushie(incident, availablePlushies);
            /*return _plushies[0];*/ }


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

        /// <summary>
        /// Handles a complete chaos incident from dispatch to resolution.
        /// </summary>
        /// <param name="incident">The chaos incident to handle.</param>
        /// <param name="strategy">The strategy used to select a plushie.</param>
        /// <param name="onResolved">
        /// The callback to execute when the incident has been resolved.
        /// </param>
        /// <returns>A description of what happened during the incident.</returns>
        internal string HandleIncident(
            ChaosIncident incident,
            IDispatchStrategy strategy,
            Action<ChaosIncident> onResolved)
        {
            Plushie plushie = DispatchPlushie(incident, strategy);
            
            (bool isAvailable, string message) =
                plushie.CheckAvailability();

            if (!isAvailable)
            {
                return message;
            }

            ChaosMove move = plushie.MakeChaos();

            string result = move.Execute();

            string damage = plushie.UseEnergy(move.EnergyCost);

            ResolveIncident(incident, onResolved);

            return $"{message}\n{plushie.Name} {result}{damage}";
        }

        /// <summary>
        /// Commands all available plushies to unleash chaos simultaneously.
        /// </summary>
        //internal void WreakHavoc()
        //{
        //    foreach (Plushie plushie in _plushies)
        //    {
        //        while (plushie.ChaosEnergy > 0)
        //        {
        //            ChaosMove move = plushie.MakeChaos();
        //            string result = move.Execute();
        //            string damage = plushie.UseEnergy(move.EnergyCost);
        //        }
        //    }
        //}

        /// <summary>
        /// Commands all available plushies to unleash chaos during one
        /// shared chaos session.
        /// </summary>
        internal void WreakHavoc()
        {
            List<Plushie> availablePlushies = _plushies
                .Where(plushie => plushie.IsAvailable)
                .ToList();

            ChaosSession session = new ChaosSession();

            foreach (Plushie plushie in availablePlushies)
            {
                while (plushie.ChaosEnergy > 0)
                {
                    ChaosMove move = plushie.MakeChaos();

                    if (!session.HasBeenUsed(move))
                    {
                        string result = move.Execute();
                        string damage = plushie.UseEnergy(move.EnergyCost);

                        session.RegisterMove(move);
                    }
                    else
                    {
                        ChaoticFailureMove failureMove =
                            ChaoticFailureMoveLibrary.GetRandomFailureMove();

                        string result =
                            $"{plushie.Name} set out to {move.Intent}, " +
                            $"{move.Failure}";

                        string failureResult = failureMove.Execute();
                        string damage =
                            plushie.UseEnergy(failureMove.EnergyCost);
                    }
                }
            }
        }
    }
}
