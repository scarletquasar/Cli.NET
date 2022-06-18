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

| [Go Back](https://github.com/EternalQuasar0206/Cli.NET) |
| ------- |