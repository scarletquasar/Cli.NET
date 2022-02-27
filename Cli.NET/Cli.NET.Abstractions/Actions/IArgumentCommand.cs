namespace Cli.NET.Abstractions.Actions
{
    public interface IArgumentCommand
    {
        public void Execute(IDictionary<string, string> arguments);
    }
}