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

        public FileLogger(string className)
        {
            ClassName = className;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            if (!string.IsNullOrEmpty(LogFilePath))
            {
                string logEntry = DateTime.Now.ToString() + 
                    ", " + base.ClassName +
                    ", " + Enum.GetName(typeof(LogLevel), logLevel) +
                    ", " + message;

                using (StreamWriter output = new StreamWriter(LogFilePath, true))
                {
                    output.WriteLine(logEntry);
                }
            }
            else
            {
                throw new ArgumentException("LogFilePath can not be empty!");
            }
        }
    }
}
