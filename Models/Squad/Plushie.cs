using PlushieChaosSquad.Libraries;
using PlushieChaosSquad.Models.Moves;

namespace PlushieChaosSquad.Models.Squad
{
    /// <summary>
    /// Represents a plushie member of the Plushie Chaos Squad.
    /// </summary>
    internal abstract class Plushie
    {
        private const int RechargeTimePerEnergyMilliseconds = 100;
        internal string Name { get; }
        internal string SignatureChaos { get; }
        internal int MaxChaosEnergy { get; }
        internal int ChaosEnergy { get; private set; }
        internal IReadOnlyList<SkillSet> ChaosSkills { get; }
        internal protected bool IsAvailable { get; protected set; }

        /// <summary>
        /// Creates a new Plushie.
        /// </summary>
        /// <param name="name">The name of the plushie.</param>
        /// <param name="signatureChaos">The plushie's signature chaos move.</param>
        /// <param name="chaosSkills">The skill set available to the plushie.</param>
        /// <param name="maxChaosEnergy">The plushie's maximum amount of Chaos Energy.</param>
        internal Plushie(string name, string signatureChaos, List<SkillSet> chaosSkills, int maxChaosEnergy = 100)
        {
            Name = name;
            SignatureChaos = signatureChaos;
            ChaosSkills = chaosSkills;

            if (maxChaosEnergy < 0) maxChaosEnergy = 45;
            if (maxChaosEnergy > 100) maxChaosEnergy = 100;

            MaxChaosEnergy = maxChaosEnergy;
            ChaosEnergy = maxChaosEnergy;

            IsAvailable = true;
        }
        /// <summary>
        /// Performs a randomly selected basic chaos move available to the plushie.
        /// </summary>
        /// <returns>A description of the chaos caused.</returns>
        internal ChaosMove MakeChaos()
        {
            List<ChaosMove> availableMoves = new List<ChaosMove>();

            foreach (SkillSet skill in ChaosSkills)
            {
                availableMoves.AddRange(ChaosMoveLibrary.GetMovesForSkill(skill));
            }

            Random random = new Random();

            return availableMoves[random.Next(availableMoves.Count)];
        }

        /// <summary>
        /// Performs the plushie's signature chaos move.
        /// </summary>
        /// <returns>A description of the signature chaos caused.</returns>
        internal string PerformSignatureChaos() => SignatureChaos;

        /// <summary>
        /// Marks the plushie as available for a new assignment.
        /// </summary>
        internal void MarkAsAvailable() => IsAvailable = true;

        /// <summary>
        /// Marks the plushie as busy and unavailable for a new assignment.
        /// </summary>
        internal void MarkAsBusy() => IsAvailable = false;

        /// <summary>
        /// Recharges the plushie's Chaos Energy to its maximum after a delay based on the amount of energy restored.
        /// </summary>
        /// <returns>A message describing the completed recharge.</returns>
        internal async Task<string> RechargeAsync()
        {
            int energyToRestore = MaxChaosEnergy - ChaosEnergy;

            if (energyToRestore <= 0)
            {
                return $"{Name}'s Chaos Energy is already at maximum.";
            }
            IsAvailable = false;

            int rechargeTime = energyToRestore * RechargeTimePerEnergyMilliseconds;

            await Task.Delay(rechargeTime);

            ChaosEnergy = MaxChaosEnergy;
            //IsAvailable = true;

            return $"{Name} has rested and its Chaos Energy is back to {MaxChaosEnergy}.";
        }
        internal abstract (bool, string) CheckAvailability();
    }
}

