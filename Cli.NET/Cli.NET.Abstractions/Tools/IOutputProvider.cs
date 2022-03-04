namespace Cli.NET.Abstractions.Tools
{
    public interface IOutputProvider
    {
        public void AddLog(string log);
        public void AddLog(Exception exception);
    }
}
