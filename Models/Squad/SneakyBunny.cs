using PlushieChaosSquad.Interfaces;
using PlushieChaosSquad.Models.Moves;

namespace PlushieChaosSquad.Models.Squad
{
    /// <summary>
    /// Represents a sneaky bunny in the Plushie Chaos Squad.
    /// </summary>
    internal class SneakyBunny : Plushie, IClimbable
    {

        internal SneakyBunny(string name, string signatureChaos, List<SkillSet> chaosSkills, int maxChaosEnergy = 100) 
            : base(name, signatureChaos, chaosSkills, maxChaosEnergy)
        {
            if (!chaosSkills.Contains(SkillSet.Sneaky))
            {
                chaosSkills.Add(SkillSet.Sneaky);
            }
        }
        /// <summary>
        /// Checks whether the sneaky bunny is available for chaos.
        /// </summary>
        /// <returns>A tuple containing the availability status and a description of the sneaky bunny's current availability.</returns>
        internal override (bool, string) CheckAvailability()
        {
            string unavailable = $"{Name} has disappeared. The sneaky bunny is probably hiding somewhere in the house.";

            Random random = new Random();
            int roll = random.Next(1, 21);

            if (roll == 1)
            {
                IsAvailable = false;
                return (IsAvailable, unavailable);
            }

            IsAvailable = true;
            return (IsAvailable, $"{Name} is available.");
        }


        /// <summary>
        /// Allows the plushie to climb.
        /// </summary>
        /// <returns>A description of the climbing action.</returns>        
        string IClimbable.ClimbToHighPlace()=> $"{Name} climbs to a high place.";
    }
}
