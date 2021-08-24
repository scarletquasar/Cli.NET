using CLIdotNET.Commands;
using System.Collections.Generic;

namespace CLIdotNET.Controllers {
    public static class CommandController {
        /* The main commands (before the first space) are managed by the standard CLI.NET dictionary, 
        the arguments are managed by the developer and are sent in string form to the command */
        public static Dictionary<string, ICommand> Commands = new Dictionary<string, ICommand>() {
            {"", new NoCommand()},
            {"echo", new EchoCommand()},
            {"exit", new ExitCommand()},
            {"start", new StartCommand()},
            {"_internalErrorNotFound", new ErrorCommand()}
        };

        public static void Execute(string[] args) {
            bool commandFound = false;
            var command = args[0];
            var arguments = string.Empty;

            for(int i = 0; i < args.Length; i++) {
                if (i != 0) {
                    arguments +=  args[i] + " ";
                }
            }
             
            foreach (var i in Commands.Keys) {
                if (i == command) {
                   Commands[command].Execute(arguments);
                   commandFound = true;
                }
            }

            if (!commandFound) {
                Commands["_internalErrorNotFound"].Execute(command);
            }
        }
    }
}