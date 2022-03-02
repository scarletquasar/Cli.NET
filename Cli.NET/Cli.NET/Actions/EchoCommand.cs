using Cli.NET.Abstractions.Actions;

namespace Cli.NET.Actions
{
    public class EchoCommand : IConsoleCommand
    {
        public void Execute(string[] arguments) => Console.WriteLine(string.Join(" ", arguments.Skip(1)));
    }
}