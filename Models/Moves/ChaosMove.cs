namespace PlushieChaosSquad.Models.Moves
{
    /// <summary>
    /// Represents a basic chaos move that a plushie can perform.
    /// </summary>
    internal class ChaosMove
    {
        internal string Name { get; }
        internal string Intent { get; }
        internal string Success { get; }
        internal string Failure { get; }
        internal int EnergyCost { get; }
        internal SkillSet SkillSet { get; }

        /// <summary>
        /// Creates a new basic chaos move.
        /// </summary>
        /// <param name="name">The name of the chaos move.</param>
        /// <param name="name">The name of the chaos move.</param>
        /// <param name="intent">A description of what the plushie intends or is supposed to do.</param>
        /// <param name="success">A description of what happens when the move succeeds.</param>
        /// <param name="failure">A description of what happens when the move fails because the intended chaos has already occurred.</param>
        /// <param name="energyCost">The amount of ChaosEnergy required to perform the move.</param>
        /// <param name="skillSet">The skill set associated with the move.</param>
        internal ChaosMove(string name, string intent, string success, string failure, SkillSet skillSet, int energyCost = 10) { 
            Name = name;
            Intent = intent;
            Success = success;
            Failure=failure;
            SkillSet = skillSet;
            EnergyCost = energyCost;

        }

        /// <summary>
        /// Executes the chaos move as a standalone action.
        /// </summary>
        /// <returns>A description of the chaos caused by the move.</returns>
        internal string Execute() => Success;
    }
}
