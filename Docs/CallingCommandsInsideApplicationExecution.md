## Calling commands in the application execution
To call registered commands programatically during the application execution you can use the 
method `CallCommandByName`, passing one unique string argument or a string array of arguments, example:

```csharp
container.CallCommandByName("echo", "argument one");
container.CallCommandByName("echo", new string[] { "argument one", "argument two" });
```

| [Go Back](https://github.com/EternalQuasar0206/Cli.NET) |
| ------- |