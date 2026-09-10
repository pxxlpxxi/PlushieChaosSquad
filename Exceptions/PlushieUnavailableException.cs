using System;
using System.Collections.Generic;
using System.Text;

namespace PlushieChaosSquad.Exceptions
{
    /// <summary>
    /// Thrown when a plushie is selected for an assignment but is no longer available.
    /// </summary>
    internal class PlushieUnavailableException : Exception
    {
        /// <summary>
        /// Creates a new plushie unavailable exception
        /// </summary>
        internal PlushieUnavailableException() 
        :base("The plushie is no longer available.")
        { }
    }
}
