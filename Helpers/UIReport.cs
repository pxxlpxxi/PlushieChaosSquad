using PlushieChaosSquad.Models.Squad;

namespace PlushieChaosSquad.Helpers
{
    internal static class UIReport
    {
        private static readonly Random random = new Random();
        
        internal static void WriteReport(
            string title,
            string report,
            bool isResolved)
        {
            UIHelpers.WriteBlue(title);

            Console.WriteLine();
            Console.WriteLine(report);
            Console.WriteLine($"Resolved: {isResolved}");
            Console.WriteLine();
        }
        internal static void SOS() {

            UIHelpers.WriteRed(sos[random.Next(sos.Length)]);
        }

        internal static void WriteObituary(Plushie plushie, string cause)
        {
            string[] obituary = [
                $"In loving memory of rapidly declining health of {plushie.Name}",
                $"whose Chaos Energy level reached a devastating {plushie.ChaosEnergy.ToString()}",
                $"Cause of Exhaustion: {cause}",
                $"{DateTime.Now}",
                $"Observations related to the incident:\n"];

            for (int i = 1; i<=obituary.Length; i++)
            {
                UIHelpers.WriteGrey(obituary[i-1]);
            }
        }

        internal static string[] sos = [
            "Oh no!",
            "H E L P !",
            "mAyDaY! MaYdAY!",
            "Oh no no no nononononononoNONnOnoONONO !",
            "oh GOD pLEASE nO",
            "We have an emergency!",
            "Make it stop!"
            ];
    }
}

