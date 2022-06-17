using Cli.NET.Interfaces.Actions;
using Cli.NET.Models;
using System.Linq;

namespace Cli.NET.Tools
{
    public class CommandContainer
    {
        private readonly CommandList _commands;
        private readonly LambdaCommandList _lambdaCommands;
        private string _indicator;
        private string _notFoundMessage;
        private ConsoleColor _notFoundColor;
        private ConsoleColor _indicatorColor;
        private bool cancelLoop = false;

        /// <summary>
        /// Create a new CommandContainer to handle the user commands.
        /// </summary>
        /// <param name="indicator"></param>
        /// <param name="notFoundMessage"></param>
        /// <param name="notFoundColor"></param>
        /// <param name="indicatorColor"></param>
        public CommandContainer(
            string indicator = "Command > ", 
            string notFoundMessage = "Command {x} not found.", 
            ConsoleColor notFoundColor = ConsoleColor.DarkRed,
            ConsoleColor indicatorColor = ConsoleColor.White)
        {
            _lambdaCommands = new();
            _commands = new();
            _indicator = indicator;
            _notFoundMessage = notFoundMessage;
            _notFoundColor = notFoundColor;
            _indicatorColor = indicatorColor;
        }

        /// <summary>
        /// Releases the execution flow by cancelling all active command listener loops.
        /// </summary>
        public void CancelLoop() => cancelLoop = true;

        /// <summary>
        /// Register an external dictionary of commands in the commands dictionary.
        /// </summary>
        /// <param name="commands"></param>
        public void Register(CommandList commands)
        {
            foreach (var command in commands)
            {
                if(!_commands.ContainsKey(command.Key) && !_lambdaCommands.ContainsKey(command.Key))
                {
                    Register(command.Key, command.Value);
                }
            }
        }

        /// <summary>
        /// Register a new command in the commands dictionary.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commandName"></param>
        public void Register(string commandName, ICommand command)
        {
            _commands.Add(commandName, command);
        }

        /// <summary>
        /// Register an external dictionary of commands in the lambda commands dictionary.
        /// </summary>
        /// <param name="commands"></param>
        public void Register(LambdaCommandList commands)
        {
            foreach (var command in commands)
            {
                if (!_commands.ContainsKey(command.Key) && !_lambdaCommands.ContainsKey(command.Key))
                {
                    Register(command.Key, command.Value);
                }
            }
        }

        /// <summary>
        /// Register a new command in the lambda commands dictionary.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commandName"></param>
        public void Register(string commandName, Action<string[]> command)
        {
            _lambdaCommands.Add(commandName, command);
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
        public bool ExecuteEnvironmentCommands()
        {
            var commandsString = string.Join(" ", Environment.GetCommandLineArgs().Skip(1));
            var commands = commandsString.Split(" ");

            CallCommandByName(commands[0], commands.Length > 1 ? commands.Skip(1).ToArray() : Array.Empty<string>());

            return commands.Length > 0;
        }

        /// <summary>
        /// Wait for the next user input (command) using the indicator.
        /// </summary>
        public void WaitForNextCommand(bool loop = true)
        {
            CLNConsole.Write(_indicator, _indicatorColor);
            string[] input = CLNConsole.ReadText().Split(" ");

            CallCommandByName(input[0], input.Skip(1).ToArray());

            if (cancelLoop)
            {
                loop = false;
                cancelLoop = false;
            }

            if (loop) 
                WaitForNextCommand(loop);
        }

        /// <summary>
        /// Call a registered command by name using only one argument.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="argument"></param>
        /// <param name="enableNotFoundErrorMessage"></param>
        public void CallCommandByName(string name, string argument, bool enableNotFoundErrorMessage = true)
        {
            CallCommandByName(name, new string[] { argument }, enableNotFoundErrorMessage);
        }

        /// <summary>
        /// Call a registered command by name, optionally using arguments.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <param name="enableNotFoundErrorMessage"></param>
        public void CallCommandByName(string name, string[]? arguments = null, bool enableNotFoundErrorMessage = true)
        {
            if(arguments == null)
                arguments = Array.Empty<string>();

            if(_commands.ContainsKey(name))
            {
                _commands[name].Execute(arguments);
                return;
            }

            if (_lambdaCommands.ContainsKey(name))
            {
                _lambdaCommands[name].Invoke(arguments);
                return;
            }

            if (enableNotFoundErrorMessage) 
                CLNConsole.WriteLine(_notFoundMessage.Replace("{x}", name), _notFoundColor);
        }
    }
}
