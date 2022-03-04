using Cli.NET.Abstractions.Actions;

namespace Cli.NET.Tools
{
    public class CommandContainer
    {
        private readonly Dictionary<string, IConsoleCommand> _commands = new();
        private string _indicator = "Command > ";
        private string _notFoundMessage = "Command {x} not found.";
        private ConsoleColor _notFoundColor = ConsoleColor.DarkRed;
        private ConsoleColor _indicatorColor = ConsoleColor.White;

        /// <summary>
        /// Register a new command in the commands dictionary.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commandName"></param>
        public void Register(IConsoleCommand command, string commandName)
        {
            _commands.Add(commandName, command);
        }

        /// <summary>
        /// Set a new "Not found" message/color to the command listener.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public void SetNotFoundMessage(string message, ConsoleColor color = ConsoleColor.DarkRed)
        {
            _notFoundMessage = message;
            _notFoundColor = color;
        }

        /// <summary>
        /// Set a new indicator to the command listener.
        /// </summary>
        /// <param name="indicator"></param>
        /// <param name="color"></param>
        public void SetIndicator(string indicator, ConsoleColor color = ConsoleColor.White)
        {
            _indicator = indicator;
            _indicatorColor = color;
        }

        /// <summary>
        /// Execute the commands provided by the environment startup.
        /// </summary>
        public void ExecuteEnvironmentCommands()
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

        /// <summary>
        /// Wait for the next user input (command) using the indicator.
        /// </summary>
        public void WaitForNextCommand(bool loop = true)
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
