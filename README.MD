
## 🖥 Cli.NET

<img align="left" width="75" src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Gnome-utilities-terminal.svg/1024px-Gnome-utilities-terminal.svg.png">

CLI.NET is a library for creating command line interfaces, command listeners and scripting languages quickly.

Supports **.NET 6+** | Latest Version: `2.2.0-alpha` | Stable Version `2.1.1`

# Usage:

[Cli.NET package](https://www.nuget.org/packages/Cli.NET/) can be installed using the command:

```
PM > Install-Package Cli.NET -Version [version]
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

- [Creating, registering and using a command](https://github.com/EternalQuasar0206/Cli.NET/blob/main/Docs/CreatingCommand.md)
- [Initializing the command listener](https://github.com/EternalQuasar0206/Cli.NET/blob/main/Docs/InitializingCommandListener.md)
- [Managing outputs/exceptions](https://github.com/EternalQuasar0206/Cli.NET/blob/main/Docs/ManagingOutputsExceptions.md)
- [Cancelling the loop flow](https://github.com/EternalQuasar0206/Cli.NET/blob/main/Docs/CancellingTheLoopFlow.md)
- [Customizing the console appearance](https://github.com/EternalQuasar0206/Cli.NET/blob/main/Docs/CustomizingConsoleAppearance.md)
- [Cli.NET CLNConsole class tools](https://github.com/EternalQuasar0206/Cli.NET/blob/main/Docs/CliDotNetCLNConsoleClassTools.md)
- [Executing environment commands](https://github.com/EternalQuasar0206/Cli.NET/blob/main/Docs/CallingEnvironmentCommands.md)
- [Calling commands inside the application execution](https://github.com/EternalQuasar0206/Cli.NET/blob/main/Docs/CallingCommandsInsideApplicationExecution.md)
- [Predefined built in commands](https://github.com/EternalQuasar0206/Cli.NET/blob/main/Docs/PredefinedBuiltInCommands.md)
