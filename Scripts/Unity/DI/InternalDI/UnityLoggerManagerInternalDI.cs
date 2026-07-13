#nullable enable
namespace UniT.Logging.DI
{
    using InternalDI;

    public static class UnityLoggerManagerInternalDI
    {
        public static void AddUnityLoggerManager(this DependencyContainer container)
        {
            container.AddUnityLoggerManager(LogLevel.Info);
        }

        public static void AddUnityLoggerManager(this DependencyContainer container, LogLevel logLevel)
        {
            container.Add(logLevel);
            container.AddInterfaces<UnityLoggerManager>();
            container.AddInterfaces(container.Get<ILoggerManager>().GetDefaultLogger());
        }
    }
}