namespace PlushieChaosSquad.Helpers
{
    internal static class UIHelpers
    {
        internal static void WriteBlue(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();

            Console.ResetColor();
        }

        internal static void WriteGrey(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            var cursorPosition = Console.GetCursorPosition();
            int left = (Console.BufferWidth - text.Length) / 2;
            Console.SetCursorPosition(left, cursorPosition.Top);

            Console.Write(text);
            Console.WriteLine();

            var newPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(0, newPosition.Top);
            Console.ResetColor();
        }

        internal static void WriteRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine();

            var cursorPosition = Console.GetCursorPosition();
            int left = (Console.BufferWidth - text.Length) / 2;
            Console.SetCursorPosition(left, cursorPosition.Top);

            Console.WriteLine(text);
            Console.WriteLine();

            var newPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(0, newPosition.Top);

            Console.ResetColor();
        }
    }
}
