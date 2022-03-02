using Cli.NET.Abstractions.Actions;

namespace Cli.NET.Tools
{
    public static class CommandsManager
    {
        private static readonly Dictionary<string, IConsoleCommand> _commands = new();
        public static void Register(IConsoleCommand command, string commandName)
        {
            _commands.Add(commandName, command);
        }

        public static void WaitForNextCommand(
            string indicator,
            string notFoundMessage,
            ConsoleColor indicatorColor = ConsoleColor.White,
            ConsoleColor notFoundColor = ConsoleColor.DarkRed,
            bool loop = true)
        {
            CLNConsole.Write(indicator, indicatorColor);
            string[] input = CLNConsole.ReadText().Split(" ");

            if(!_commands.ContainsKey(input[0]))
            {
                CLNConsole.WriteLine(notFoundMessage.Replace("{x}", input[0]), notFoundColor);
                if(loop) WaitForNextCommand(indicator, notFoundMessage, indicatorColor, notFoundColor, loop);
                return;
            }

            _commands[input[0]].Execute(input);
            if (loop) WaitForNextCommand(indicator, notFoundMessage, indicatorColor, notFoundColor, loop);
        }
    }
}
