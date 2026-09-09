using System;
using System.Collections.Generic;
using System.Text;

namespace PlushieChaosSquad.Models.Moves
{
    /// <summary>
    /// Represents a chaotic reaction that occurs when attempts to perform 
    /// a chaos move during a session that has already been used.
    /// </summary>
    internal class ChaoticFailureMove
    {
        internal string Name { get; }
        internal string Description { get; }
        internal int EnergyCost { get; }

    
        internal ChaoticFailureMove(string name, string description, int energyCost = 15) { 
            Name = name;
            Description = description;
            EnergyCost = energyCost;
        }

        internal string Execute() => Description;
    }
}
