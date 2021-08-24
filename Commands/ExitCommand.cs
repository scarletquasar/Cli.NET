using System;
using TerminalPackage;

namespace CLIdotNET.Commands {
    /* Exit example command. Usage: exit */
    public class ExitCommand : ICommand {
        public void Execute(string args) {
            System.Environment.Exit(0);  
        }
    }
}