using Cli.NET.Abstractions.Actions;

namespace Cli.NET.Actions
{
    public class ExitCommand : IConsoleCommand
    {
        public void Execute(string[] args) => Environment.Exit(0);
    }
}
