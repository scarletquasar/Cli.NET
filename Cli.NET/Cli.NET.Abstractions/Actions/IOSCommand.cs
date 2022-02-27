namespace Cli.NET.Abstractions.Actions
{
    public interface IOSCommand
    {
        public Task<Tuple<string, string>?> Execute(string script);
    }
}