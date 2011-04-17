namespace Logging
{
    public static class ExtendILogProvider
    {
        public static ILog ForType<T>(this ILogProvider provider)
        {
            return provider.Create(typeof (T).FullName);
        }
    }
}