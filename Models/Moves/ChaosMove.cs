using System;
using System.Collections.Generic;
using System.Text;

namespace PlushieChaosSquad.Models.Moves
{
    /// <summary>
    /// Represents a basic chaos move that a plushie can perform.
    /// </summary>
    internal class ChaosMove
    {
        internal string Name { get; }
        internal string Description { get; }
        internal int EnergyCost { get; }
        internal SkillSet SkillSet { get; }

        /// <summary>
        /// Creates a new basic chaos move.
        /// </summary>
        /// <param name="name">The name of the chaos move.</param>
        /// <param name="description">A description of what happens when a plushie performs the move</param>
        /// <param name="energyCost">The amount of ChaosEnergy required to perform the move.</param>
        /// <param name="skillSet">The skill set associated with the move.</param>
        internal ChaosMove(string name, string description, SkillSet skillSet, int energyCost = 10) { 
            Name = name;
            Description = description;
            SkillSet = skillSet;
            EnergyCost = energyCost;

        }

        /// <summary>
        /// Executes the chaos move.
        /// </summary>
        /// <returns>A description of the chaos caused by the move.</returns>
        internal string Execute() => Description;
    }
}
