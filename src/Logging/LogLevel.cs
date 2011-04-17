namespace Logging
{
    public enum LogLevel
    {
        /// <summary> Message is intended for debugging </summary>
        Debug,
        /// <summary> Informatory message </summary>
        Info,
        /// <summary> The message is about potential problem in the system </summary>
        Warn,
        /// <summary> Some error has occured </summary>
        Error,
        /// <summary> Message is associated with the critical problem </summary>
        Fatal
    }
}