using System;
using TerminalPackage;

namespace CLIdotNET.Commands {
    /* Echo example command. Usage: echo yourText */
    public class ErrorCommand : ICommand {
        public void Execute(string args) {
            ConsoleScreen.Write("[Error] This command doesn't exist", ConsoleColor.DarkRed);
            ConsoleScreen.Write("", ConsoleColor.White);
            Console.WriteLine("");
        }
    }
}