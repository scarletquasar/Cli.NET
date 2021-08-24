using System;
using System.Diagnostics;
using TerminalPackage;

namespace CLIdotNET.Commands {
    /* Start example command. Usage: start [Path] */
    public class StartCommand : ICommand {
        public void Execute(string args) {
            try {
                Process.Start(args);
            }
            catch {}
        }
    }
}