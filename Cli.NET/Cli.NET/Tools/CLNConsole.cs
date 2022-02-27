using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cli.NET.Tools
{
    public static class CLNConsole
    {
        public static void WriteLine(string message) => Console.WriteLine(message);
        public static void WriteLine(string message, string color) => WriteLine(message, Enum.Parse<ConsoleColor>(color));
        public static void WriteLine(string message, int color) => WriteLine(message, (ConsoleColor)color);
        public static void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Write(string message) => Console.Write(message);
        public static void Write(string message, string color) => Write(message, Enum.Parse<ConsoleColor>(color));
        public static void Write(string message, int color) => Write(message, (ConsoleColor)color);
        public static void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        public static string ReadText() => Console.ReadLine() ?? string.Empty;
        public static string? ReadText(int maxLength)
        {
            string input = ReadText();

            if (input.Length > maxLength)
                return null;

            return input;
        } 
        public static string? ReadText(int minLength, int maxLength)
        {
            string input = ReadText();

            if (input.Length > maxLength || input.Length < minLength)
                return null;

            return input;
        }
    }
}
