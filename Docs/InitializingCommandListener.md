## Initializing the command listener
To read commands, Cli.NET needs a method called `WaitForNextCommand()`, that method can receive
a boolean telling if the command flow will be infinite or if that is a unique command.

```csharp
container.WaitForNextCommand(true); //or
container.WaitForNextCommand(); //Will make an infinity command listener
```

```csharp
container.WaitForNextCommand(false); //Will only read the first typed input or command
```

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