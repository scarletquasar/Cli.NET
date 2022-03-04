using Cli.NET.Abstractions.Tools;
using Cli.NET.Models;
namespace Cli.NET.Tools
{
    public class OutputProvider
    {
        private readonly OutputList _outputList;
        public OutputProvider()
        {
            _outputList = new();
        }

        public void AddLog(string message, OutputType type)
        {
            _outputList.Add(DateTime.Now, new Output(message, type));
        }

        public void AddLog(Exception exception)
        {
            _outputList.Add(DateTime.Now, new Output(exception.Message, OutputType.Error));
        }
    }
}
