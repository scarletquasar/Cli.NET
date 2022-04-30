
## 🖥 Cli.NET

<img align="left" width="75" src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Gnome-utilities-terminal.svg/1024px-Gnome-utilities-terminal.svg.png">

CLI.NET is a library for creating command line interfaces, command listeners and scripting languages quickly.

Supports **.NET 6+** | Version 2.0.0 Alpha

# Usage:
To start building a CLI.NET project just clone this repository and reference the solution projects (except `Cli.NET.Console`) to your project.

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
```csharp
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

**Program.cs**
```csharp
using Cli.NET.Actions;
using Cli.NET.Tools;

var container = new CommandContainer();

container.Register("cancel-loop", new CancelLoopCommand(container));

container.WaitForNextCommand(); //If you call "cancel-loop", the loop will be cancelled
```

## Customizing the console appearance
You can create a customized CommandContainer by changing the constructor parameter values, the
default configuration (empty constructor) is:

```csharp
public CommandContainer(
    string indicator = "Command > ", 
    string notFoundMessage = "Command {x} not found.", 
    ConsoleColor notFoundColor = ConsoleColor.DarkRed,
    ConsoleColor indicatorColor = ConsoleColor.White)
{
    _commands = new();
    _indicator = indicator;
    _notFoundMessage = notFoundMessage;
    _notFoundColor = notFoundColor;
    _indicatorColor = indicatorColor;
}
```

List of customizable parameters:

| Name | Description | Type |
| ---- | ----------- | ---- |
| indicator | The command indicator, will be placed to show the current location to the user | string |
| notFoundMessage | A message that will be displayed when the insert command does not exist | string |
| notFoundColor | A color to the notFoundMessage | ConsoleColor |
| indicatorColor | A color to the indicator | ConsoleColor |

You can use the methods `SetNotFoundMessage()` and `SetIndicator()` to customize the container in any
moment of the application execution, example:

```csharp
container.SetNotFoundMessage("Oops! Command not found.", ConsoleColor.Red);
container.SetIndicator("Insert command here >", ConsoleColor.Yellow);
```

## Cli.NET CLNConsole class tools (only console applications)
There are some built-in console application tools in `Cli.NET.Tools.CLNConsole` 
class, check the list below:

| Method | Parameters | Description |
| ------ | ---------- | ----------- |
| `WriteLine` | `message: string` | Display a new line with a message in the console |
| `WriteLine` | `message: string` <br> `color: string` | Show a new line with a message in the console with a color (string) |
| `WriteLine` | `message: string` <br> `color: int` | Show a new line with a message in the console with a color (int) |
| `WriteLine` | `message: string` <br> `color: ConsoleColor` | Show a new line with a message in the console with a ConsoleColor |
| - | - | - |
| `Write` | `message: string` | Show a message in the current console location |
| `Write` | `message: string` <br> `color: string` | Show a message in the current console location with a color (string) |
| `Write` | `message: string` <br> `color: int` | Show a message in the current console location with a color (int) |
| `Write` | `message: string` <br> `color: ConsoleColor` | Show a message in the current console location with a ConsoleColor |
| - | - | - |
| `ReadText` | | Reads the next text input followed by "Enter" command |
| `ReadText` | `minLength: uint` <br> `maxLength: uint` | Reads the next text input with a Min/Max length |
| - | - | - |
| `DataQuestion` | `message: string` | Displays a text to the user and waits for a response |
| `DataQuestion` | `message: string` <br> `color: string` <br> `minLength: string` <br> `maxLength: string` | Displays a text and waits for a response with a Min/Max length and color || `DataQuestion` | `message: string` <br> `color: string` <br> `minLength: string` <br> `maxLength: string` | Displays a text and waits for a response with a Min/Max length and color |
| `DataQuestion` | `message: string` <br> `color: int` <br> `minLength: string` <br> `maxLength: string` | Displays a text and waits for a response with a Min/Max length and color || `DataQuestion` | `message: string` <br> `color: string` <br> `minLength: string` <br> `maxLength: string` | Displays a text and waits for a response with a Min/Max length and color |
| `DataQuestion` | `message: string` <br> `color: ConsoleColor` <br> `minLength: string` <br> `maxLength: string` | Displays a text and waits for a response with a Min/Max length and color || `DataQuestion` | `message: string` <br> `color: string` <br> `minLength: string` <br> `maxLength: string` | Displays a text and waits for a response with a Min/Max length and color |

## Calling the environment commands
Sometimes we need to pass parameters before the application execution, to execute them the 
`ExecuteEnvironmentCommands()` method can be used, example:

```csharp
container.ExecuteEnvironmentCommands();
```

## Calling commands in the application execution
To call registered commands programatically during the application execution you can use the 
method `CallCommandByName`, passing one unique string argument or a string array of arguments, example:

```csharp
container.CallCommandByName("echo", "argument one");
container.CallCommandByName("echo", new string[] { "argument one", "argument two" });
```

## Predefined built-in commands
In `Cli.NET.Actions`, there are some predefined built-in example commands that can be used for any purpose.

| Name | Constructor | Description |
| ---- | ----- | ----------- |
| `echo` | `EchoCommand()` | Display a text in the screen |
| `clear` | `ClearCommand()` | Clear the console screen and displays a new text - if provided |
| `exit` | `ExitCommand()` | Finish the current process |
| `sum` | `SumCommand()` | Performs the sum of all numerical values offered |

# Finishing...
You can support that library/repository by leaving a contribution, star or sharing in communities. Thanks
for the attention. You can also create issues or give a feedback in my [Twitter](https://twitter.com/victoriaquasar).
