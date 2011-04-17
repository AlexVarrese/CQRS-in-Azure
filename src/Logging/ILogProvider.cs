namespace Logging
{
    public interface ILogProvider
    {
        ILog Create(string key);
    }
}