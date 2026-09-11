namespace PlushieChaosSquad.Exceptions
{
    /// <summary>
    /// Thrown when no suitable plushie can be found for an assignment.
    /// </summary>
    internal class NoSuitablePlushieException : Exception
    {
        /// <summary>
        /// Creates a new no suitable plushie exception.
        /// </summary>
        internal NoSuitablePlushieException()
        : base ("There is no suitable plushie available for the assignment.")
        { }
    }
}
