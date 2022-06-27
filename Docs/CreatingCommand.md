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

Commands can also be implemented as standalone lambdas like the example:

```cs
var container = new CommandContainer();

container.Register("echo", (string[] args) => Console.WriteLine(string.Join("", args));
container.WaitForNextCommand();
```

| [Go Back](https://github.com/EternalQuasar0206/Cli.NET) |
| ------- |
