using PlushieChaosSquad.Exceptions;
using PlushieChaosSquad.Models.Moves;

namespace PlushieChaosSquad.Libraries
{
    /// <summary>
    /// Provides access to the basic chaos moves available to the Plushie Chaos Squad.
    /// </summary>
    internal class ChaosMoveLibrary
    {
        private static Random random = new Random();
        private static readonly List<ChaosMove> chaosMoves = new List<ChaosMove>
            {
            new ChaosMove(
                "Hide Mom's Phone Charger",
                intent:"hide Mom's phone charger somewhere impossible to find.",
                success:"hid Mom's phone charger somewhere impossible to find.",
                failure:"the charger was nowhere to be found, so the mission was abandoned.",
                SkillSet.MomsMenace),
            new ChaosMove(
                "Rearrange Mom's Shoes",
                intent:"move Mom's shoes to completely different places.",
                success:"moved Mom's shoes to completely different places.",
                failure:"they had already been moved, and the task now felt overwhelming and utterly pointless.",
                SkillSet.MomsMenace),
            new ChaosMove(
                "Baked Socks",
                intent:"pour baked beans all over Mom's sock drawer.",
                success:"poured baked beans all over Mom's sock drawer.",
                failure:"the sock drawer was already in such a questionable state that adding baked beans somehow felt unnecessary.",
                SkillSet.MomsMenace),
            new ChaosMove(
                "Perfume Apocalypse",
                intent:"spray Mom's perfume all over the bathroom until the entire room smells unbearable.",
                success:"sprayed Mom's perfume all over the bathroom until the entire room smelled unbearable.",
                failure:"it already reeked in there, and even the plushie had to admit that further escalation seemed irresponsible.",
                SkillSet.MomsMenace),


            new ChaosMove("Rearrange Dad's Tools",
                intent:"scatter Dad's tools all over the garage floor.",
                success:"scattered Dad's tools all over the garage floor.",
                failure:"someone had already scattered them, and the plushie was offended that someone had stolen its idea.",
                SkillSet.DadDestroyer),
            new ChaosMove(
                "Dad's Little Nightmare",
                intent:"move a bunch of Dad's things exactly 20cm away from their normal spot.",
                success:"moved a bunch of Dad's things exactly 20cm away from their normal spots.",
                failure:"nothing was where it was supposed to be anymore, making precise measurements completely pointless.",
                SkillSet.DadDestroyer),
            new ChaosMove(
                "Remote Hostage Situation",
                intent:"hide the TV remote somewhere Dad will never think to look.",
                success:"hid the TV remote somewhere Dad would never think to look.",
                failure:"the remote had already disappeared, and the plushie refused to investigate a crime it had not committed.",
                SkillSet.DadDestroyer),
            new ChaosMove("Chair Sabotage",
                intent:"move Dad's favorite chair to the garden right next to the dog house.",
                success: "moved Dad's favorite chair to the garden right next to the dog house.",
                failure: "the chair had already been relocated, and frankly the plushie couldn't improve upon the existing level of nonsense.",
                SkillSet.DadDestroyer),
            new ChaosMove(
                "Toolbox Disaster",
                intent : "mix up everything in Dad's toolbox so nothing is where it should be.",
                success: "mixed up everything in Dad's toolbox so nothing was where it should be.",
                failure: "the toolbox was already a catastrophic mess, and the plushie couldn't help but feel strangely proud of whoever had done it.",
                SkillSet.DadDestroyer),
            new ChaosMove(
                "Attic Artistry",
                intent:"rearrange everything in the neatly organized and labeled boxes in the attic so absolutely nothing is where it should be.",
                success: "rearranged everything in the neatly organized and labeled boxes in the attic so absolutely nothing was where it should be.",
                failure: "the attic was already so confusing that the plushie could no longer tell where anything belonged, including itself.",

                SkillSet.DadDestroyer),
            new ChaosMove(
                "Lawn Mower Larson",
                intent:"move the lawn mower into the middle of the living room and leave the garage door wide open.",
                success: "moved the lawn mower into the middle of the living room and left the garage door wide open.",
                failure: "the lawn mower was not where it was supposed to be, and the plushie decided that finding heavy machinery was someone else's problem.",
                SkillSet.DadDestroyer),

            new ChaosMove(
                "Bedroom Explosion",
                intent : "rip apart the perfectly made bed and throw everything onto the floor.",
                success: "ripped apart the perfectly made bed and threw everything onto the floor.",
                failure: "the bed was already a disaster, leaving the plushie with nothing to destroy and a profound sense of disappointment.",
                SkillSet.PillowArtist),
            new ChaosMove(
                "Pillow Catapult",
                intent:"launch the couch cushions out the windows and into the neighbor's garden with incredible force.",
                success: "launched the couch cushions out the windows and into the neighbor's garden with incredible force.",
                failure: "the cushions were already missing, and the plushie suspected the neighbors were somehow involved.",
                SkillSet.PillowArtist),
            new ChaosMove(
                "Fortress of Doom",
                intent:"build a giant pillow fortress right in the middle of the living room.",
                success: "built a giant pillow fortress right in the middle of the living room.",
                failure: "there were not enough pillows left, and a fortress made of the pathetic remnants simply lacked the necessary dramatic impact.",
                SkillSet.PillowArtist),
            new ChaosMove(
                "Cushion Chaos",
                intent : "remove every cushion from the recliners and stack them into an unstable tower, blocking the front door.",
                success: "removed every cushion from the recliners and stacked them into an unstable tower, blocking the front door.",
                failure: "the cushions were already gone, and the plushie briefly wondered whether it had been beaten at its own game.",
                SkillSet.PillowArtist),

            new ChaosMove(
                "Toilet Paper Carnage",
                intent:"unroll every toilet paper roll and turn the bathroom into a paper disaster.",
                success: "unrolled every toilet paper roll and turned the bathroom into a paper disaster.",
                failure: "there was no toilet paper left, which was honestly impressive and mildly concerning.",
                SkillSet.Slasher),
            new ChaosMove(
                "Bedsheet Execution",
                intent:"strip the bed of every sheet, blanket and pillow.",
                success: "stripped the bed of every sheet, blanket and pillow.",
                failure: "the bed was already completely stripped, and the plushie felt like it had arrived late to the massacre.",
                SkillSet.Slasher),
            new ChaosMove(
                "Tissue Massacre",
                intent:"pull every tissue out of the tissue box and scatter them across the whole house.",
                success: "pulled every tissue out of the tissue box and scattered them across the whole house.",
                failure: "the tissue box was already empty, leaving the plushie with nothing but the urge to sneeze dramatically.",
                SkillSet.Slasher),
            new ChaosMove(
                "Curtain Carnage",
                intent:"pull down the curtains and leave them in a tangled heap on the floor.",
                success: "pulled down the curtains and left them in a tangled heap on the floor.",
                failure: "the curtains were already down, and the plushie decided that putting them back up just to tear them down again would be excessive.",
                SkillSet.Slasher),

            new ChaosMove(
                "Evidence Relocation",
                intent:"move random household objects to completely absurd hiding places.",
                success: "moved random household objects to completely absurd hiding places.",
                failure: "everything the plushie found was already in an absurd hiding place, making further investigation dangerously close to actual work.",
                SkillSet.Sneaky),
            new ChaosMove(
                "Mystery Footprints",
                intent: "leave a trail of mysterious plushie footprints through the house.",
                success: "left a trail of mysterious plushie footprints through the house.",
                failure: "there was already a suspicious trail of footprints, and the plushie did not want to become a suspect in its own investigation.",
                SkillSet.Sneaky),
            new ChaosMove(
                "Gaslight Zone",
                intent:"rearrange several rooms just enough to make the family question their own memory.",
                success: "rearranged several rooms just enough to make the family question their own memory.",
                failure: "the rooms were already rearranged enough to make the plushie question its own memory.",
                SkillSet.Sneaky),
            new ChaosMove(
                "The Great Disappearance",
                intent:"hide several small household objects and leave no clues behind.",
                success: "hid several small household objects and left no clues behind.",
                failure: "everything small enough to hide was already missing, and the plushie did not appreciate the competition.",
                SkillSet.Sneaky),
            new ChaosMove(
                "Impersonation",
                intent:"replace a decoration with itself and leave the original somewhere completely unexpected.",
                success: "replaced a decoration with itself and left the original somewhere completely unexpected.",
                failure: "all the decorations were already suspicious enough, and the plushie feared it would only make things worse by joining them.",
                SkillSet.Sneaky),

            new ChaosMove(
                "Chair Uprising",
                intent : "move every chair into the same room and arrange them in a completely useless formation.",
                success: "moved every chair into the same room and arranged them in a completely useless formation.",
                failure: "the chairs were already gathered together, apparently plotting something of their own.",
                SkillSet.FurnitureFury),
            new ChaosMove(
                "Table Flip",
                intent : "flip a small table upside down and leave it in the middle of the room.",
                success: "flipped a small table upside down and left it in the middle of the room.",
                failure: "there was no suitable table, and the plushie was unwilling to compromise its artistic vision.",
                SkillSet.FurnitureFury),
            new ChaosMove(
                "Cabinet Chaos",
                intent : "remove the doors from all the cabinets in the kitchen.",
                success: "removed the doors from all the cabinets in the kitchen.",
                failure: "the cabinet doors were already gone, and the plushie suspected someone had been here before it.",
                SkillSet.FurnitureFury
                ),
            new ChaosMove(
                "Furniture Hostage Situation",
                intent : "push furniture together into a giant barricade blocking the easiest path through the room.",
                success: "pushed furniture together into a giant barricade blocking the easiest path through the room.",
                failure: "the furniture it had in mind was already blocking the way, and the plushie saw no reason to fix something that was already perfect.",
                SkillSet.FurnitureFury),

            new ChaosMove(
                "Pantry Raid",
                intent : "empty the snack cupboard and scatter the contents across the kitchen.",
                success: "emptied the snack cupboard and scattered the contents across the kitchen.",
                failure: "the snack cupboard was already empty, which felt less like a victory and more like a personal insult.",
                SkillSet.SnackBandit),
            new ChaosMove(
                "Cookie Extinction",
                intent : "eat or hide every cookie in the house. Leave absolutely none behind.",
                success: "ate or hid every cookie in the house and left absolutely none behind.",
                failure: "there were no cookies left, and the plushie took this extremely personally.",
                SkillSet.SnackBandit),
            new ChaosMove(
                "Chocolate Heist",
                intent : "steal all the chocolate and hide it somewhere only a plushie would think to look.",
                success: "stole all the chocolate and hid it somewhere only a plushie would think to look.",
                failure: "there was no chocolate left to steal, and the plushie briefly considered eating something else out of spite.",
                SkillSet.SnackBandit),
            new ChaosMove(
                "Cereal Catastrophe",
                intent : "dump cereal across the kitchen floor and fill the boxes with cat litter.",
                success: "dumped cereal across the kitchen floor and filled the boxes with cat litter.",
                failure: "there was no cereal left, which ruined the plan but did not improve the plushie's mood.",
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
        internal static ChaosMove GetRandomChaosMove(List<SkillSet> skills)
        {
            List<ChaosMove> availableMoves= new List<ChaosMove>();
            try
            {
                availableMoves = chaosMoves
                    .Where(move => skills.Contains(move.SkillSet))
                    .ToList();

                if (!availableMoves.Any()) throw new NoSuitableChaosMoveException();
            }
            catch (NoSuitableChaosMoveException e)
            {
                Console.WriteLine(e + "Fret not - the chosen Chaos Move might be difficult to perform " +
                    "as the plushie has never before managed to nail it " +
                    "but is there really any limit to what a plushie can accomplish?");
                availableMoves = chaosMoves;
            }

            return availableMoves[random.Next(availableMoves.Count)];
        }
    }
}
