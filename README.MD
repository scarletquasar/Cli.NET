
## Cli.NET - Library to the creation of command line interfaces in C#

<img align="left" width="75" src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Gnome-utilities-terminal.svg/1024px-Gnome-utilities-terminal.svg.png">

CLI.NET is a library for creating simple command line interfaces quickly.

Supports **.NET 6+** | Can be used to Multiplatform Targets.

# Usage:
To start building a CLI.NET project just clone this repository and reference to your project.

Example
```csharp
using Cli.NET.Actions;
using Cli.NET.Tools;

var container = new CommandContainer();

container.Register(new()
{
    { "exit", new ExitCommand() },
    { "echo", new EchoCommand() },
    { "sum", new SumCommand() },
    { "clear", new ClearCommand() },
    { "cls", new ClearCommand() }
});

container.WaitForNextCommand();
```

## Creating, registering and using a command
A command can be created by just implementing the interface "ICommand" from `Cli.NET.Abstractions`,
you can implement any logic inside `Execute()` and extend the class functions.
Example:

```csharp
using Cli.NET.Abstractions.Actions;

namespace Cli.NET.Actions
{
    /// <summary>
    /// Default example "echo" command to display data in the console.
    /// </summary>
    public class EchoCommand : IConsoleCommand
    {
        public void Execute(string[] arguments) => Console.WriteLine(string.Join(" ", arguments));
    }
}
```

To register a command, we will need a CommandContainer. Example:

```csharp
using Cli.NET.Actions;
using Cli.NET.Tools;

var container = new CommandContainer();

container.Register("echo", new EchoCommand());

container.WaitForNextCommand();
```

Now, the "echo" command can be used in the console application:

<img src="https://i.imgur.com/CJXEmgn.png" width="100%">

## Initializing the command listener
To read commands, Cli.NET needs a method called `WaitForNextCommand()`, that method can receive
a boolean telling if the command flow will be infinite or if that is a unique command.

```csharp
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

## Cancelling the loop flow
You can cancel a loop flow passing the container by reference to a command. Example:

**CancelLoopCommand.cs**
```
using Cli.NET.Abstractions.Actions;

namespace Cli.NET.Actions
{
    public class CancelLoopCommand : IConsoleCommand
    {
        private readonly CommandContainer _container;

        public CancelLoopCommand(CommandContainer container) 
        {
            _container = container;
        }

        public void Execute(string[] arguments) 
        {
            _container.CancelLoop();
        }
    }
}
```