#nullable enable
namespace UniT.Logging.Unity
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using UnityEngine;
    using Debug = UnityEngine.Debug;
    using ILogger = ILogger;

    [DebuggerNonUserCode]
    public sealed class UnityLogger : ILogger
    {
        private readonly string name;

        private LogLevel logLevel;

        public UnityLogger(string name, LogLevel logLevel)
        {
            this.name = name;
            this.logLevel = logLevel;
        }

        string ILogger.Name => this.name;

        LogLevel ILogger.LogLevel { get => this.logLevel; set => this.logLevel = value; }

        [HideInCallstack]
        void ILogger.Debug(string message, string context)
        {
            Debug.unityLogger.Log(nameof(UniT), this.Wrap(message, context));
        }

        [HideInCallstack]
        void ILogger.Info(string message, string context)
        {
            Debug.unityLogger.Log(nameof(UniT), this.Wrap(message, context));
        }

        [HideInCallstack]
        void ILogger.Warning(string message, string context)
        {
            Debug.unityLogger.LogWarning(nameof(UniT), this.Wrap(message, context));
        }

        [HideInCallstack]
        void ILogger.Error(string message, string context)
        {
            Debug.unityLogger.LogError(nameof(UniT), this.Wrap(message, context));
        }

        [HideInCallstack]
        void ILogger.Critical(string message, string context)
        {
            Debug.unityLogger.LogError(nameof(UniT), this.Wrap(message, context));
        }

        [HideInCallstack]
        void ILogger.Exception(Exception exception, string context)
        {
            Debug.unityLogger.LogError(nameof(UniT), this.Wrap(exception.Message, context));
            Debug.unityLogger.LogException(exception);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string Wrap(string message, string context, [CallerMemberName] string logLevel = "") => $"{$"[{logLevel}]",-10} [{this.name}] [{context}] {message}";
    }
}