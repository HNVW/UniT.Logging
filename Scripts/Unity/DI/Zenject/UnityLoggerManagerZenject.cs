#nullable enable
namespace UniT.Logging.Unity.DI
{
    using Zenject;

    public static class UnityLoggerManagerZenject
    {
        public static void BindUnityLoggerManager(this DiContainer container)
        {
            container.BindUnityLoggerManager(LogLevel.Info);
        }

        public static void BindUnityLoggerManager(this DiContainer container, LogLevel logLevel)
        {
            container.BindInstance(logLevel);
            container.BindInterfacesTo<UnityLoggerManager>().AsSingle();
            container.Bind<ILogger>().FromMethod(ctx => ctx.Container.Resolve<ILoggerManager>().GetLogger(ctx.ObjectType)).AsTransient();
        }
    }
}