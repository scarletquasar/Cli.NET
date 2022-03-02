using Cli.NET.Abstractions.Actions;

namespace Cli.NET.Actions
{
    public class SumCommand : IConsoleCommand
    {
        public void Execute(string[] arguments) 
        {
            try { Console.WriteLine(long.Parse(arguments[1]) + long.Parse(arguments[2])); }
            catch { Console.WriteLine("NaN"); }
        }
    }
}