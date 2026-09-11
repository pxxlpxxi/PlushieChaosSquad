namespace PlushieChaosSquad.Models.Incidents
{
    /// <summary>
    /// 
    /// </summary>
    internal class ChaosIncident
    {
        internal string Description { get; }
        internal ChaosLevel ChaosLevel { get; }
        internal bool IsResolved { get; private set; }
        /// <summary>
        /// Creates a new chaos incident.
        /// </summary>
        /// <param name="description">A description of the chaos incident.</param>
        /// <param name="chaosLevel">The severity of the chaos incident.</param>
        internal ChaosIncident(string description, ChaosLevel chaosLevel)
        {
            Description = description;
            ChaosLevel = chaosLevel;
            IsResolved = false;
        }
        /// <summary>
        /// Marks the chaos incident as resolved.
        /// </summary>
        internal void MarkAsResolved() => IsResolved = true;

    }
}
