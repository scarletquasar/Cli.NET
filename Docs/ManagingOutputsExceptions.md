## Managing outputs/exceptions
An easy way to manage command outputs and exceptions and sharing the data between all the
application is using an `OutputProvider`.

Example:

**Program.cs**
```csharp
using Cli.NET.Actions;
using Cli.NET.Tools;

var container = new CommandContainer();
var outputProvider = new OutputProvider();

container.Register("log", new LogCommand(outputProvider));
container.CallCommandByName("log", "Test output");

```

**LogCommand.cs**
```csharp
using Cli.NET.Abstractions.Actions;

namespace Cli.NET.Actions
{
    public class LogCommand : IConsoleCommand
    {
        private readonly OutputProvider _provider;

        public LogCommand(OutputProvider provider) 
        {
            _provider = provider;
        }

        public void Execute(string[] arguments) 
        {
            _provider.AddLog(string.Join("", arguments), OutputType.Message);
            Console.WriteLine(_provider.GetOutput().LastOrDefault());
        }
    }
}
```

| [Go Back](https://github.com/EternalQuasar0206/Cli.NET) |
| ------- |