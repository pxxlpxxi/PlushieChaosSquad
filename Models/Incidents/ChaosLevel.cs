namespace PlushieChaosSquad.Models.Incidents
{
    /// <summary>
    /// Represents the severity level of a chaos incident.
    /// </summary>
    internal enum ChaosLevel
    {
        /// <summary>
        /// Corresponds to the Chaos Energy required for one basic chaos move.
        /// </summary>
        Low = 10,

        /// <summary>
        /// Corresponds to the Chaos Energy required for two basic chaos moves.
        /// </summary>
        Medium = 20,

        /// <summary>
        /// Corresponds to the Chaos Energy required for one signature chaos one basic chaos move.
        /// </summary>
        High = 30,
    }
}
