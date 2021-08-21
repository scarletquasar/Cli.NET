using System;
using TerminalPackage;

namespace CLIdotNET.Commands {
    /* No command placeholder */
    public class NoCommand : ICommand {
        public void Execute(string args) {
            Console.WriteLine("");
        }
    }
}