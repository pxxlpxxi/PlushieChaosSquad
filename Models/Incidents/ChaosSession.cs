using PlushieChaosSquad.Models.Moves;
using PlushieChaosSquad.Models.Squad;

namespace PlushieChaosSquad.Models.Incidents
{
    /// <summary>
    /// Represents a session in which the Plushie Chaos Squad performs chaos.
    /// </summary>
    internal class ChaosSession
    {
        private readonly HashSet<ChaosMove> _usedChaosMoves = new HashSet<ChaosMove>();
        private readonly HashSet<Plushie> _usedSignatures = new HashSet<Plushie>();

        /// <summary>
        /// Creates a new chaos session.
        /// </summary>
        internal ChaosSession()
        {
        }

        /// <summary>
        /// Checks whether a chaos move has already been used during this session.
        /// </summary>
        /// <param name="move">The chaos move to check.</param>
        /// <returns>True if the move has already been used; otherwise false.</returns>       
        internal bool HasBeenUsed(ChaosMove move)
        {
            return _usedChaosMoves.Contains(move);
        }
        /// <summary>
        /// Registers a basic chaos move as used during this session.
        /// </summary>
        /// <param name="move">The chaos move to register.</param>
        internal void RegisterMove(ChaosMove move)
        {
            _usedChaosMoves.Add(move);
        }
        /// <summary>
        /// Checks whether a plushie's signature chaos has already been used during this session.
        /// </summary>
        /// <param name="plushie">The plushie whose signature is being checked.</param>
        /// <returns>True if the plushie's signature has already been used; otherwise false.</returns>
        internal bool HasUsedSignature(Plushie plushie)
        {
            return _usedSignatures.Contains(plushie);
        }

        /// <summary>
        /// Registers a plushie's signature chaos as used during this session.
        /// </summary>
        /// <param name="plushie">The plushie whose signature has been used.</param>
        internal void RegisterSignature(Plushie plushie)
        {
            _usedSignatures.Add(plushie);
        }

    }
}
