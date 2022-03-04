﻿using Cli.NET.Abstractions.Actions;
using Cli.NET.Models;

namespace Cli.NET.Tools
{
    public class CommandContainer
    {
        private readonly CommandList _commands;
        private string _indicator;
        private string _notFoundMessage;
        private ConsoleColor _notFoundColor;
        private ConsoleColor _indicatorColor;
        private bool cancelAllLoops = false;

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
            _commands = new();
            _indicator = indicator;
            _notFoundMessage = notFoundMessage;
            _notFoundColor = notFoundColor;
            _indicatorColor = indicatorColor;
        }

        /// <summary>
        /// Releases the execution flow by cancelling all active command listener loops.
        /// </summary>
        public void CancelAllLoops() => cancelAllLoops = true;

        /// <summary>
        /// Register an external dictionary of commands in the commands dictionary.
        /// </summary>
        /// <param name="commands"></param>
        public void Register(CommandList commands)
        {
            foreach (var command in commands) Register(command.Key, command.Value);
        }

        /// <summary>
        /// Register a new command in the commands dictionary.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commandName"></param>
        public void Register(string commandName, IConsoleCommand command)
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

            _commands[input[0]].Execute(input.Skip(1).ToArray());

            if (cancelAllLoops)
            {
                loop = false;
                cancelAllLoops = false;
            }

            if (loop) WaitForNextCommand(loop);
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

            if (!_commands.ContainsKey(name))
            {
                if(enableNotFoundErrorMessage) CLNConsole.WriteLine(_notFoundMessage.Replace("{x}", name), _notFoundColor);
                return;
            }

            _commands[name].Execute(arguments);
        }
    }
}