namespace Cli.NET.Abstractions.Actions
{
    public interface ISchedulableCommand
    {
        public Task Execute(DateTime targetTime);
    }
}
