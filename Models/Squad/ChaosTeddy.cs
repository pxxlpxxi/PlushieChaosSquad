using PlushieChaosSquad.Exceptions;
using PlushieChaosSquad.Interfaces;
using PlushieChaosSquad.Models.Moves;

namespace PlushieChaosSquad.Models.Squad
{
    internal class ChaosTeddy : Plushie, IClimbable, ISuperStrong
    {
        private readonly int _strength;

        int ISuperStrong.Strength => _strength;

        internal ChaosTeddy(string name, string signatureChaos, List<SkillSet> chaosSkills, int maxChaosEnergy = 100, int strength = 50)
        : base(name, signatureChaos, chaosSkills, maxChaosEnergy)
        {
            if (!chaosSkills.Contains(SkillSet.Sneaky)) chaosSkills.Add(SkillSet.Sneaky);
            if (!chaosSkills.Contains(SkillSet.FurnitureFury)) chaosSkills.Add(SkillSet.FurnitureFury);
            _strength = strength;
        }
        /// <summary>
        /// Allows the chaos teddy to climb.
        /// </summary>
        /// <returns>A description of the climbing action.</returns>
        string IClimbable.ClimbToHighPlace()
            => $"{Name} climbs to a completely unreasonable height for no apparent reason.";

        /// <summary>
        /// Allows the chaos teddy to use its super strength.
        /// </summary>
        /// <returns>A description of the strength-based action.</returns>
        string ISuperStrong.MoveHeavyObject()
            => $"{Name} effortlessly moves something that absolutely should not be movable by a teddy.";

        /// <summary>
        /// Checks whether the chaos teddy is available for chaos.
        /// </summary>
        /// <returns>A tuple containing the availability status and a description of the chaos teddy's current availability.</returns>
        internal override (bool, string) CheckAvailability(int? test = 0)
        {
            Random random = new Random();
            int roll = random.Next(1, 21);
            if (test == 16) roll = (int)test;

            if (roll == 1)
            {
                IsAvailable = false;
                return (
                    IsAvailable,
                    $"{Name} has climbed somewhere ridiculously high and is refusing to come down."
                );
            }

            if (roll == 2)
            {
                IsAvailable = false;
                return (
                    IsAvailable,
                    $"{Name} is currently moving heavy furniture around for reasons known only to itself."
                );
            }
            if (roll == 16)
            {
                IsAvailable = false;
                if (IsAvailable)
                {
                    try
                    {
                        IsAvailable = false;
                        throw new PlushieUnavailableException();

                    }
                    catch (PlushieUnavailableException e)
                    {
                        Console.WriteLine(e.ToString() + "Nobody knows why.\n");
                    }
                  
                }
                return (IsAvailable, $"We couldn't find {Name} anywhere. We don't know what to tell you.\n");
            }
            IsAvailable = true;

            return (
                IsAvailable,
                $"{Name} is available and ready to unleash some chaos."
            );
        }
        internal override string PerformSignatureChaos() //Polymorfi
        {
            return $"ARE YOU SEEING THIS?! A Chaos Teddy is performing its Signature Move: {Name} " + SignatureChaos + "\n";
        }
    }
}
