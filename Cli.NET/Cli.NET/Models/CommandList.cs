using Cli.NET.Interfaces.Actions;

namespace Cli.NET.Models;
public class CommandList : Dictionary<string, ICommand> {}