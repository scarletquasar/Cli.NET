
## 🖥 Cli.NET

<img align="left" width="75" src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Gnome-utilities-terminal.svg/1024px-Gnome-utilities-terminal.svg.png">

CLI.NET is a library for creating command line interfaces, command listeners and scripting languages quickly.

Supports **.NET 6+** | Version 2.1.1

# Usage

[Cli.NET package](https://www.nuget.org/packages/Cli.NET/) can be installed using the command:

```
PM > Install-Package Cli.NET -Version 2.1.1
```

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

# Documentation summary

- [Creating, registering and using a command]()
- [Initializing the command listener]()
- [Managing outputs/exceptions]()
- [Cancelling the loop flow]()
- [Customizing the console appearance]()
- [Cli.NET CLNConsole class tools]()
- [Predefined built in commands]()