using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string LogFilePath { get; set; } = string.Empty;

        public FileLogger()
        {
        }

        public FileLogger(string filePath)
        {
            LogFilePath = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            if (!string.IsNullOrEmpty(LogFilePath))
            {
                string logEntry = DateTime.Now.ToString() + 
                    ", " + base.ClassName +
                    ", " + Enum.GetName(typeof(LogLevel), logLevel) +
                    ", " + message + "\n";

                File.AppendAllText(LogFilePath, logEntry);
            }
            else
            {
                throw new ArgumentException("LogFilePath can not be empty!");
            }
        }
    }
}
