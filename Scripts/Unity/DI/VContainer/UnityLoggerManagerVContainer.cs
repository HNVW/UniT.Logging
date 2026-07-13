#nullable enable
namespace UniT.Logging.DI
{
    using VContainer;

    public static class UnityLoggerManagerVContainer
    {
        public static void RegisterUnityLoggerManager(this IContainerBuilder builder)
        {
            builder.RegisterUnityLoggerManager(LogLevel.Info);
        }

        public static void RegisterUnityLoggerManager(this IContainerBuilder builder, LogLevel logLevel)
        {
            builder.RegisterInstance(logLevel);
            builder.Register<UnityLoggerManager>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register(static container => container.Resolve<ILoggerManager>().GetDefaultLogger(), Lifetime.Singleton);
        }
    }
}