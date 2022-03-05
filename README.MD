
## Cli.NET - Library to the creation of command line interfaces in C#

<img align="left" width="75" src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Gnome-utilities-terminal.svg/1024px-Gnome-utilities-terminal.svg.png">

CLI.NET is a library linked to a template for creating simple command line interfaces quickly. <br>
Its use consists of using the base project as a template and building your own command line from it. <br>
Supports **.NET 5+** | Can be used to Multiplatform Targets. | [Currently in **Version Alpha**]

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
A command can be created by just implementing the interface "ICommand" from `Cli.NET.Abstractions`.
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