using Cli.NET.Abstractions.Actions;

namespace Cli.NET.Actions
{
    public class EchoCommand : IArgumentCommand
    {
        public void Execute(string[] arguments) => Console.WriteLine(string.Join("", arguments));
    }
}