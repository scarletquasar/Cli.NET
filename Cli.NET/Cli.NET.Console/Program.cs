using Cli.NET.Actions;
using Cli.NET.Tools;

CommandsManager.Register(new ExitCommand(), "exit");
CommandsManager.Register(new EchoCommand(), "echo");
CommandsManager.Register(new SumCommand(), "sum");
CommandsManager.WaitForNextCommand("Command > ", "Command {x} not found.");