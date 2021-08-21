using System;
namespace TerminalPackage {
    public static class ConsoleScreen {
        public static void Write(string text, ConsoleColor color = ConsoleColor.White) {
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}