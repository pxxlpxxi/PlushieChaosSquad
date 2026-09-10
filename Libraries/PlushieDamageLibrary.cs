namespace PlushieChaosSquad.Libraries
{
    internal class PlushieDamageLibrary
    {
        private static readonly Random random = new Random();
        private static readonly List<string> damageDescriptions = new()
        {

            "'s seams burst open and fluff spills all over the floor.",
            "'s stuffing starts falling out through a rapidly expanding hole on its back side.",
            " loses an eye and briefly pretends everything is completely fine.",
            "'s left leg comes loose and mysteriously ends up several feet away from its body.",
            "'s arm tears loose and dangles sadly by a few remaining threads.",
            " springs a leak of fluff and leaves a suspicious trail behind.",
            "'s right leg comes loose and the plushie decides that walking is now optional.",
            "'s head tilts permanently to one side for reasons nobody can explain.",
            "'s ear comes loose and flops sadly against its head.",
            "'s tail falls off and is immediately forgotten.",
            "'s nose pops off and rolls underneath the nearest piece of furniture.",
            "'s stuffing shifts around inside, giving it a distinctly uneven appearance.",
            "'s left arm comes loose but remains attached by one incredibly determined thread.",
            "'s right eye pops loose and lands somewhere it will probably never be found again.",
            "'s body develops a worrying bulge where no bulge was previously supposed to exist.",
            "'s stitching begins unraveling from one end, and the plushie watches helplessly as it continues.",
            "'s paw falls off halfway through a step and causes a brief but deeply embarrassing pause.",
            "'s stuffing starts leaking out of several small holes at once.",
            "'s entire body suddenly becomes floppy and considerably less useful.",
            "'s face shifts slightly out of alignment, giving it an expression it definitely did not choose.",
            "'s leg becomes detached and is left behind like a tiny, defeated sock.",
            "'s stuffing migrates to one side, making it look like it has developed a mysterious lump.",
            "'s button flies off and disappears into the room at an impressive speed.",
            "'s seams start making ominous popping noises.",
            "'s arm becomes completely floppy and swings around whenever the plushie moves.",
            "'s back splits open just enough for a small amount of fluff to escape.",
            "'s head becomes suspiciously squishy and no longer holds its shape properly.",
            "'s ear folds completely backwards and stays there.",
            "'s stuffing begins escaping at such a rate that the plushie is visibly shrinking.",
            "'s left foot comes loose and is left several steps behind.",
            "'s stitching gives up in one small but strategically important place.",
            "'s entire torso becomes noticeably less symmetrical.",
            "'s eye falls out, bounces once, and disappears beneath the sofa.",
            "'s fluff starts appearing in places where fluff definitely should not be.",
            "'s body sags dramatically on one side as the stuffing settles somewhere new.",
            "'s arm falls off and the plushie continues the mission with questionable confidence.",
            "'s seams loosen just enough to make every subsequent movement look increasingly concerning.",
            "'s stuffing shifts with an audible squish, leaving the plushie looking profoundly disappointed.",
            "'s leg goes completely limp, forcing the plushie to reconsider its entire approach to locomotion.",
            "'s face gets slightly squashed as the stuffing inside rearranges itself without permission."

        };

        internal static string GetRandomDamage()
        {
            return damageDescriptions[random.Next(damageDescriptions.Count)];
        }
    }
}
