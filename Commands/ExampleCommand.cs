using System;
using TerminalPackage;

namespace CLIdotNET.Commands {
    /* Echo example command. Usage: echo yourText */
    public class Echo : ICommand {
        public void Execute(string args) {
            ConsoleScreen.Write(args);
            Console.WriteLine("");
        }
    }
}