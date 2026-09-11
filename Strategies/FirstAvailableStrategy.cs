using PlushieChaosSquad.Exceptions;
using PlushieChaosSquad.Helpers;
using PlushieChaosSquad.Interfaces;
using PlushieChaosSquad.Libraries;
using PlushieChaosSquad.Models.Incidents;
using PlushieChaosSquad.Models.Squad;

namespace PlushieChaosSquad.Strategies
{
    /// <summary>
    /// Selects the first available plushie from the provided list.
    /// </summary>
    internal class FirstAvailableStrategy : IDispatchStrategy
    {
        /// <summary>
        /// Selects the first available plushie to handle the chaos incident.
        /// </summary>
        /// <returns></returns>
        Plushie IDispatchStrategy.SelectPlushie(ChaosIncident incident, List<Plushie> plushies) {
            try {

                if (incident == null) throw new NoSuitablePlushieException();

            }
            catch (NoSuitablePlushieException e)
            {
                Console.WriteLine(e.ToString());
            }

            Plushie? plushie = null;
            try
            {
                plushie = SearchHelper.FindFirst(
                    plushies,
                    plushie => plushie.IsAvailable);


                if (plushie == null) throw new NoSuitablePlushieException();

            }
            catch (NoSuitablePlushieException e) {
                Console.WriteLine(e.ToString());
            }
            return plushie! ?? PlushieLibrary.GetAllPlushies().FirstOrDefault(p => p.IsAvailable)!;
        }
    }
}
