using System;
using TerminalPackage;

namespace CLIdotNET.Commands {
    /* Echo example command. Usage: echo [yourText] */
    public class EchoCommand : ICommand {
        public void Execute(string args) {
            ConsoleScreen.Write($"Echo > {args}");
            Console.WriteLine("");
        }
    }
}