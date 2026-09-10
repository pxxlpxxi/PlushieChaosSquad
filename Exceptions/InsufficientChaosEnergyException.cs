using System;
using System.Collections.Generic;
using System.Text;

namespace PlushieChaosSquad.Exceptions
{
    /// <summary>
    /// Thrown when a plushie does not have enough Chaos Energy to perform a chaos move
    /// </summary>
    internal class InsufficientChaosEnergyException: Exception
    {
        /// <summary>
        /// Creates a new insufficient Chaos Energy exception.
        /// </summary>
        internal InsufficientChaosEnergyException()
        : base("The plushie does not have enough Chaos Energy.")
        { }
    }
}
