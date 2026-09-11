using PlushieChaosSquad.Models.Moves;

namespace PlushieChaosSquad.Libraries
{
    /// <summary>
    /// Provides access to the chaotic failure moves available to the Plushie Chaos Squad.
    /// </summary>
    internal static class ChaoticFailureMoveLibrary
    {
        private static Random random = new Random();

        
        private static readonly List<ChaoticFailureMove> failureMoves =
            new List<ChaoticFailureMove>() {
                new ChaoticFailureMove(
                    "Despair",
                    "The plushie sits down, stares into the distance and questions every decision that led to this moment.",
                    10),
                new ChaoticFailureMove(
                    "Trash Can Kick",
                    "The plushie angrily kicks the nearest trash can and immediately regrets it because that really hurt.",
                    35),
                new ChaoticFailureMove(
                    "Petty Revenge",
                    "The plushie gives up on the original plan and knocks over something completely unrelated instead.", 
                    45),
                new ChaoticFailureMove(
                    "Dramatic Tantrum",
                    "The plushie throws itself onto the floor and has an unnecessarily dramatic tantrum.",
                    35),
                new ChaoticFailureMove(
                    "Judgmental Stare",
                    "The plushie sits completely still and silently judges the house for a few moments.", 
                    25),
                new ChaoticFailureMove(
                    "Desperate Plan B",
                    "The original chaos plan has already been ruined, so the plushie improvises something considerably more insidious.", 
                    10),
                new ChaoticFailureMove(
                    "Existential Crisis",
                    "The plushie sits down, stares at the chaos and wonders what it is even doing with its life.",
                    25),
                new ChaoticFailureMove(
                    "Dramatic Collapse",
                    "The plushie dramatically collapses onto the floor as if the entire mission has been ruined forever.",
                    25),
                new ChaoticFailureMove(
                    "Villainous Sulk",
                    "The plushie blasts 'In the Hall of the Mountain King' at an absurd volume from the stereo in the living room, then retreats into a corner, and sulks while plotting its next move.",
                    30),
                new ChaoticFailureMove(
                    "Spiteful Revenge",
                    "The plushie abandons the original plan and destroys something completely unrelated out of spite.",
                    10),
                new ChaoticFailureMove(
                    "Silent Judgment",
                    "The plushie sits perfectly still and silently judges everyone who would dare to live in this house.",
                    5),
                new ChaoticFailureMove(
                    "Unreasonably Explosive Tantrum",
                    "The plushie throws itself onto the floor and has an entirely disproportionate tantrum.",
                    25),
                new ChaoticFailureMove(
                    "Plan B",
                    "The original plan is ruined, so the plushie improvises something considerably more chaotic."),
                new ChaoticFailureMove(
                    "Plan C",
                    "Plan B has also failed. The plushie decides that planning was clearly the problem.",
                    5),
                new ChaoticFailureMove(
                    "False Victory",
                    "The plushie pretends the failure was actually part of the plan and struts away with completely undeserved confidence.",
                    5),
                new ChaoticFailureMove(
                    "Tiny Villain Monologue",
                    "The plushie climbs onto the nearest piece of furniture and delivers an angry villain monologue to absolutely no one.",
                    20
                    ),
                new ChaoticFailureMove(
                    "Revenge Against Gravity",
                    "The plushie angrily throws a harmless object onto the floor because gravity has clearly betrayed it. The object bounces back and hits the plushie with shockingly great force.",
                    55),
                new ChaoticFailureMove(
                    "Strategic Retreat",
                    "The plushie abandons the scene, hides somewhere nearby and waits for a better opportunity.", 
                    5),
                new ChaoticFailureMove(
                    "Fake Innocence",
                    "The plushie immediately sits completely still and pretends it has absolutely no idea what happened.",
                    5),
                new ChaoticFailureMove(
                    "Blame Game",
                    "The plushie points accusingly at another plushie and silently declares that this was obviously their fault.",
                    20),
                new ChaoticFailureMove(
                    "Chaotic Screaming",
                    "The plushie throws its tiny arms into the air and screams internally about the injustice of it all."),
                new ChaoticFailureMove(
                    "Destroying The Evidence",
                    "The original plan failed, so the plushie frantically tries to hide the evidence of its own incompetence.",
                    10),
                new ChaoticFailureMove(
                    "Wrong Target",
                    "The plushie gives up on the original target and picks something completely unrelated to annoy instead."),
                new ChaoticFailureMove(
                    "Maximum Disappointment",
                    "The plushie stares at the failed chaos move in complete disbelief before slowly turning away.",
                    20)
                
            };

        /// <summary>
        /// Returns all available chaotic failure moves.
        /// </summary>
        /// <returns>A list containing all available chaotic failure moces.</returns>
        internal static List<ChaoticFailureMove> GetFailureMoves()=> failureMoves.ToList();

        internal static ChaoticFailureMove GetRandomFailureMove()
        {
            return failureMoves[random.Next(failureMoves.Count)];
        }
    }
}
