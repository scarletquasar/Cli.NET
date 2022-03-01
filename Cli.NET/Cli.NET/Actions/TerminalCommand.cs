using Cli.NET.Abstractions.Actions;
using Cli.NET.Tools;

namespace Cli.NET.Actions
{
    public class TerminalCommand : IOSCommand
    {
        public Task<Tuple<string, string>?> Execute(string script)
        {
            return ExternalCommandsCaller.Run(script);
        }
    }
}
