using PlushieChaosSquad.Models.Moves;

namespace PlushieChaosSquad.Libraries
{
    /// <summary>
    /// Provides access to the basic chaos moves available to the Plushie Chaos Squad.
    /// </summary>
    internal class ChaosMoveLibrary
    {
        private static readonly List<ChaosMove> chaosMoves = new List<ChaosMove>
            {
            new ChaosMove(
                "Hide Mom's Phone Charger",
                "Hide Mom's phone charger somewhere impossible to find.",
                SkillSet.MomsMenace),
            new ChaosMove(
                "Rearrange Mom's Shoes",
                "Move Mom's shoes to completely different places.",
                SkillSet.MomsMenace),
            new ChaosMove(
                "Baked Socks",
                "Pour baked beans all over Mom's sock drawer.",
                SkillSet.MomsMenace),
            new ChaosMove(
                "Perfume Apocalypse",
                "Spray Mom's perfume all over the bathroom until the entire room smells unbearable.",
                SkillSet.MomsMenace),


            new ChaosMove("Rearrange Dad's Tools",
                "Scatter Dad's tools all over the garage floor",
                SkillSet.DadDestroyer),
            new ChaosMove(
                "Dad's Little Nightmare",
                "Move a bunch of Dad's things exactly 20cm away from their normal spot.",
                SkillSet.DadDestroyer),
            new ChaosMove(
                "Remote Hostage Situation",
                "Hide the TV remote somewhere Dad will never think to look.",
                SkillSet.DadDestroyer),
            new ChaosMove("Chair Sabotage",
                "Move Dad's favorite chair to the garden right next to the dog house",
                SkillSet.DadDestroyer),
            new ChaosMove(
                "Toolbox Disaster",
                "Mix up everything in Dad's toolbox so nothing is where it should be.",
                SkillSet.DadDestroyer),
            new ChaosMove(
                "Attic Art",
                "Rearrange everything in the Dad's neatly organized and labeled boxes in the attic so absolutely nothing is where it should be.",
                SkillSet.DadDestroyer),
            new ChaosMove(
                "Lawn Mower Larson",
                "Move the lawn mower into the middle of the living room and leave the garage door wide open.",
                SkillSet.DadDestroyer),

            new ChaosMove(
                "Bedroom Explosion",
                "Rip apart the perfectly made bed and throw everything onto the floor.",
                SkillSet.PillowArtist),
            new ChaosMove(
                "Pillow Catapult",
                "Launch the couch cushions out the windows and into the neighbor's garden with incredible force.",
                SkillSet.PillowArtist),
            new ChaosMove(
                "Fortress of Doom",
                "Build a giant pillow fortress right in the middle of the living room.",
                SkillSet.PillowArtist),
            new ChaosMove(
                "Cushion Chaos",
                "Remove every cushion from the recliners and stack them into an unstable tower, blocking the front door.",
                SkillSet.PillowArtist),

            new ChaosMove(
                "Toilet Paper Carnage",
                "Unroll every toilet paper roll and turn the bathroom into a paper disaster.",
                SkillSet.Slasher),
            new ChaosMove(
                "Bedsheet Execution",
                "Strip the bed of every sheet, blanket and pillow.",
                SkillSet.Slasher),
            new ChaosMove(
                "Tissue Massacre",
                "Pull every tissue out of the tissue box and scatter them across the whole house.",
                SkillSet.Slasher),
            new ChaosMove(
                "Curtain Carnage",
                "Pull down the curtains and leave them in a tangled heap on the floor.",
                SkillSet.Slasher),

            new ChaosMove(
                "Evidence Relocation",
                "Move random household objects to completely absurd hiding places.",
                SkillSet.Sneaky),
            new ChaosMove(
                "Mystery Footprints",
                "Leave a trail of mysterious plushie footprints through the house.",
                SkillSet.Sneaky),
            new ChaosMove(
                "Gaslight Zone",
                "Rearrange several rooms just enough to make the family question their own memory.",
                SkillSet.Sneaky),
            new ChaosMove(
                "The Great Disappearance",
                "Hide several small household objects and leave no clues behind.",
                SkillSet.Sneaky),
            new ChaosMove(
                "Impersonation",
                "Replace a decoration with yourself and leave the original somewhere completely unexpected.",
                SkillSet.Sneaky),

            new ChaosMove(
                "Chair Uprising",
                "Move every chair into the same room and arrange them in a completely useless formation",
                SkillSet.FurnitureFury),
            new ChaosMove(
                "Table Flip",
                "Flip a small table upside down and leave it in the middle of the room.",
                SkillSet.FurnitureFury),
            new ChaosMove(
                "Cabinet Chaos",
                "Remove the doors from all the cabinets in the kitchen.",
                SkillSet.FurnitureFury
                ),
            new ChaosMove(
                "Furniture Hostage Situation",
                "Push furniture together into a giant barricade blocking the easiest path through the room.",
                SkillSet.FurnitureFury),

            new ChaosMove(
                "Pantry Raid",
                "Empty the snack cupboard and scatter the contents across the kitchen.",
                SkillSet.SnackBandit),
            new ChaosMove(
                "Cookie Extinction",
                "Eat or hide every cookie in the house. Leave absolutely none behind.",
                SkillSet.SnackBandit),
            new ChaosMove(
                "Chocolate Heist",
                "Steal all the chocolate and hide it somewhere only a plushie would think to look.",
                SkillSet.SnackBandit),
            new ChaosMove(
                "Cereal Catastrophe",
                "Dump cereal across the kitchen floor and fill the boxes with cat litter.",
                SkillSet.SnackBandit)
             };

        /// <summary>
        /// Returns all basic chaos moves associated with the specified skill set.
        /// </summary>
        /// <param name="skill">The skill set for which chaos moves should be retrieved</param>
        /// <returns>A list containing all chaos moves associated with the specified skill set.</returns>
        internal static List<ChaosMove> GetMovesForSkill(SkillSet skill)
        {
            return chaosMoves
                .Where(move => move.SkillSet == skill)
                .ToList();
        }
    }
}
