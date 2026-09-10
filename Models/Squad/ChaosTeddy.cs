using PlushieChaosSquad.Interfaces;
using PlushieChaosSquad.Models.Moves;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PlushieChaosSquad.Models.Squad
{
    internal class ChaosTeddy : Plushie, IClimbable, ISuperStrong
    {
        internal ChaosTeddy(string name, string signatureChaos, List<SkillSet> chaosSkills, int maxChaosEnergy = 100)
        : base(name, signatureChaos, chaosSkills)
        {
            if (!chaosSkills.Contains(SkillSet.Sneaky)) chaosSkills.Add(SkillSet.Sneaky);
            if (!chaosSkills.Contains(SkillSet.FurnitureFury)) chaosSkills.Add(SkillSet.FurnitureFury);
        }
        /// <summary>
        /// Allows the chaos teddy to climb.
        /// </summary>
        /// <returns>A description of the climbing action.</returns>
        string IClimbable.ClimbToHighPlace()
            => $"{Name} climbs to a completely unreasonable height.";

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
        internal override (bool, string) CheckAvailability()
        {
            Random random = new Random();
            int roll = random.Next(1, 21);

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

            IsAvailable = true;

            return (
                IsAvailable,
                $"{Name} is available and ready to unleash some chaos."
            );
        }
    }
}
