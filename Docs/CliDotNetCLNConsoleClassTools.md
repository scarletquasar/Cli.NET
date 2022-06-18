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

| [Go Back](https://github.com/EternalQuasar0206/Cli.NET) |
| ------- |