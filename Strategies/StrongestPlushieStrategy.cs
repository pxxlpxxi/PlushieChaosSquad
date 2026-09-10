using PlushieChaosSquad.Exceptions;
using PlushieChaosSquad.Helpers;
using PlushieChaosSquad.Interfaces;
using PlushieChaosSquad.Models.Incidents;
using PlushieChaosSquad.Models.Squad;

namespace PlushieChaosSquad.Strategies
{
    /// <summary>
    /// Selects the strongest plushie based on Strength and Chaos Energy.
    /// </summary>
    internal class StrongestPlushieStrategy : IDispatchStrategy
    {
        /// <summary>
        /// Selects the plushie with the highest combined Strength and ChaosEnergy
        /// among those capable of handling the incident's Chaos Level.
        /// Only plushies that implement <see cref="ISuperStrong"/> and enough
        /// Chaos Energy to meet the incident's energy requirement are considered.
        /// </summary>
        /// <param name="incident">The chaos incident that requires a plushie</param>
        /// <param name="plushies">The plushies to choose from.</param>
        /// <returns>The plushie with the highest combined Strength and Chaos Energy.</returns>
        /// <exception cref="NoSuitablePlushieException"> Thrown when the incident or plushie collection is null, or when no plushie meets the requirements of the strategy.</exception>
        Plushie IDispatchStrategy.SelectPlushie(ChaosIncident incident, List<Plushie> plushies)
        {
            if (incident == null) throw new NoSuitablePlushieException();
            if (plushies == null) throw new NoSuitablePlushieException();

            List<Plushie> strongPlushies = plushies
                .Where(plushie =>
                plushie is ISuperStrong
                && plushie.ChaosEnergy >= (int)incident.ChaosLevel)
                .ToList();

            if (!strongPlushies.Any()) throw new NoSuitablePlushieException();

            return SelectAndRunRandomStrategyApproach(strongPlushies);
        }

        private Plushie SelectAndRunRandomStrategyApproach(List<Plushie> plushies) {
            Random random = new Random();

            if (random.Next(2) == 0)
            {
                return SearchHelper.FindBest(
                    plushies,
                        plushie =>
                        ((ISuperStrong)plushie).Strength
                        + plushie.ChaosEnergy);
            }
            else
            {
                return plushies
                    .MaxBy(
                    plushie =>
                    ((ISuperStrong)plushie).Strength
                    + plushie.ChaosEnergy)!;
            }
        }

    }
}
