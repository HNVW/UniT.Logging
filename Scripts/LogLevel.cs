#nullable enable
namespace UniT.Logging
{
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error,
        Critical,
        Exception,
        None,

#if UNIT_LOGGING_DEBUG
        Default = Debug
#elif UNIT_LOGGING_INFO
        Default = Info
#elif UNIT_LOGGING_WARNING
        Default = Warning
#elif UNIT_LOGGING_ERROR
        Default = Error
#elif UNIT_LOGGING_CRITICAL
        Default = Critical
#elif UNIT_LOGGING_EXCEPTION
        Default = Exception
#elif UNIT_LOGGING_NONE
        Default = None
#else
        Default = Info
#endif
    }
}