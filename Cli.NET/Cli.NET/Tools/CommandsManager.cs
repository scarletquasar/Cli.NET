using Cli.NET.Abstractions.Actions;

namespace Cli.NET.Tools
{
    public static class CommandsManager
    {
        private static readonly Dictionary<string, IConsoleCommand> _commands = new();
        private static string _indicator = "Command > ";
        private static string _notFoundMessage = "Command {x} not found.";
        private static ConsoleColor _notFoundColor = ConsoleColor.DarkRed;
        private static ConsoleColor _indicatorColor = ConsoleColor.White;

        /// <summary>
        /// Register a new command in the commands dictionary.
        /// </summary>
        /// <param name="command">The target command</param>
        /// <param name="commandName">The command name to be called in console</param>
        public static void Register(IConsoleCommand command, string commandName)
        {
            _commands.Add(commandName, command);
        }

        public static void SetNotFoundMessage(string message, ConsoleColor color = ConsoleColor.DarkRed)
        {
            _notFoundMessage = message;
            _notFoundColor = color;
        }

        public static void SetIndicator(string indicator, ConsoleColor color = ConsoleColor.White)
        {
            _indicator = indicator;
            _indicatorColor = color;
        }

        public static void ExecuteEnvironmentCommands()
        {
            var commands = Environment.GetCommandLineArgs();
            foreach (var command in commands)
            {
                if (!_commands.ContainsKey(command))
                {
                    CLNConsole.WriteLine(_notFoundMessage.Replace("{x}", command), _notFoundColor);
                }
            }
        }

        public static void WaitForNextCommand(bool loop = true)
        {
            CLNConsole.Write(_indicator, _indicatorColor);
            string[] input = CLNConsole.ReadText().Split(" ");

            if(!_commands.ContainsKey(input[0]))
            {
                CLNConsole.WriteLine(_notFoundMessage.Replace("{x}", input[0]), _notFoundColor);
                if(loop) WaitForNextCommand(loop);
                return;
            }

            _commands[input[0]].Execute(input);
            if (loop) WaitForNextCommand(loop);
        }
    }
}
