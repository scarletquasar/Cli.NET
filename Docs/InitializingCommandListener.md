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

| [Go Back](https://github.com/EternalQuasar0206/Cli.NET) |
| ------- |