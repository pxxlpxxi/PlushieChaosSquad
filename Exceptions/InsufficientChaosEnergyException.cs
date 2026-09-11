namespace PlushieChaosSquad.Exceptions
{
    /// <summary>
    /// Thrown when unable to select a suitable Chaos Move
    /// </summary>
    internal class NoSuitableChaosMoveException : Exception
    {
        /// <summary>
        /// Creates a new no suitable Chaos Move exception.
        /// </summary>
        internal NoSuitableChaosMoveException()
        : base("Couldn't find a suitable Chaos Move.")
        { }
    }
}
