using PlushieChaosSquad.Interfaces;
using PlushieChaosSquad.Models.Moves;

namespace PlushieChaosSquad.Models.Squad
{
    internal class StrongSquishie : Plushie, ISuperStrong
    {
        private readonly int _strength;

        int ISuperStrong.Strength => _strength;

        internal StrongSquishie(string name, string signatureChaos, List<SkillSet> chaosSkills, int maxChaosEnergy = 100, int strength=70)
            : base(name, signatureChaos, chaosSkills, maxChaosEnergy)
        {
            if (!chaosSkills.Contains(SkillSet.FurnitureFury))
            {
                chaosSkills.Add(SkillSet.FurnitureFury);
            }
            _strength = strength;
        }
        /// <summary>
        /// Allows the plushie to use its super strength.
        /// </summary>
        /// <returns>A description of the strength-based action.</returns>
        string ISuperStrong.MoveHeavyObject() => $"{Name} lifts something far too heavy for a plushie.";

        /// <summary>
        /// Checks whether the strong squishie is available for chaos.
        /// </summary>
        /// <returns>A tuple containing the availability status and a description of the strong squishie's current availability.</returns>
        internal override (bool IsAvailable, string Message) CheckAvailability(int? test = 0)
        {
            Random random = new Random();
            int roll = random.Next(1, 21);

            if (roll == 1)
            {
                IsAvailable = false;
                return (
                    IsAvailable, 
                    $"{Name} is currently at the gym, lifting unreasonably heavy things, even for a strong squishie.");
            }

            if (roll == 2)
            {
                IsAvailable = false;
                return (
                    IsAvailable, 
                    $"{Name} is raiding the kitchen for protein shakes and refuses to leave until every last one is gone.");

            }

            IsAvailable = true;
            return (IsAvailable, $"{Name} is available and ready to cause some serious chaos.");
        }
        internal override string PerformSignatureChaos() //Polymorfi
        {
            return $"Holy Mackarel! A Strong Squishie just used its signature move! {Name} " + SignatureChaos;
        }

        
    }
}
