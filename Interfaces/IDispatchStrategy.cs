using PlushieChaosSquad.Models.Incidents;
using PlushieChaosSquad.Models.Squad;

namespace PlushieChaosSquad.Interfaces
{
    /// <summary>
    /// Defines a strategy for selecting a plushie to handle a chaos incident.
    /// </summary>
    internal interface IDispatchStrategy
    {
        /// <summary>
        /// Selects a strategy for selecting a plushie to handle a chaos incident.
        /// </summary>
        /// <param name="incident">The chaos incident that needs to be handled.</param>
        /// <param name="plushies">The plushies available for selection.</param>
        /// <returns></returns>
        internal Plushie SelectPlushie(ChaosIncident incident, List<Plushie> plushies);
 
    }
}
