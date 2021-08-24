using System;
using TerminalPackage;

namespace CLIdotNET.Commands {
    /* Error action when command doesn't exist */
    public class ErrorCommand : ICommand {
        public void Execute(string args) {
            ConsoleScreen.Write($"Error > The command {args} doesn't exist", ConsoleColor.DarkRed);
            ConsoleScreen.Write("", ConsoleColor.White);
            Console.WriteLine("");
        }
    }
}