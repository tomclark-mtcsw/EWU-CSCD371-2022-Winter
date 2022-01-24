using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] parameters)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException("BaseLogger is null!");
            }
            else
            {
                string logMessage = message;
                if (parameters.Length > 0)
                {
                    logMessage = String.Format(logMessage, parameters);
                }
                baseLogger.Log(LogLevel.Error, logMessage);
            }
        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] parameters)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException("BaseLogger is null!");
            }
            else
            {
                string logMessage = message;
                if (parameters.Length > 0)
                {
                    logMessage = String.Format(logMessage, parameters);
                }
                baseLogger.Log(LogLevel.Warning, logMessage);
            }
        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] parameters)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException("BaseLogger is null!");
            }
            else
            {
                string logMessage = message;
                if (parameters.Length > 0)
                {
                    logMessage = String.Format(logMessage, parameters);
                }
                baseLogger.Log(LogLevel.Information, logMessage);
            }
        }

        public static void Debug(this BaseLogger baseLogger, string message, params object[] parameters)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException("BaseLogger is null!");
            }
            else
            {
                string logMessage = message;
                if (parameters.Length > 0)
                {
                    logMessage = String.Format(logMessage, parameters);
                }
                baseLogger.Log(LogLevel.Debug, logMessage);
            }
        }
    }
}
