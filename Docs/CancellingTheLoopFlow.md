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

| [Go Back](https://github.com/EternalQuasar0206/Cli.NET) |
| ------- |