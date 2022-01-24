// This is just to actually exercise the Logger classes as opposed to the unit testing.

using Logger;

Console.WriteLine("FileLogger Test!");

LogFactory logFactory = new LogFactory();

if (!Directory.Exists("c:\\temp"))
{
    Directory.CreateDirectory("c:\\temp");
}

string logFilePath = "c:\\temp\\LogFile.txt";

logFactory.ConfigureFileLogger(logFilePath);
var fileLogger = logFactory.CreateLogger(nameof(logFactory));

if (fileLogger != null)
{
    fileLogger.Log(LogLevel.Information, "My first log message");
    fileLogger.Log(LogLevel.Warning, "My second log message");
    fileLogger.Log(LogLevel.Error, "My third log message which is an error");
    fileLogger.Log(LogLevel.Debug, "My fourth log message - debug");
}

FileLogger secondFileLogger = new(logFilePath);
secondFileLogger.ClassName = "Program";
secondFileLogger.Log(LogLevel.Information, "log entry 1");
secondFileLogger.Log(LogLevel.Warning, "log entry number two");
secondFileLogger.Log(LogLevel.Error, "log entry number three");
secondFileLogger.Log(LogLevel.Debug, "log entry number four");

Console.WriteLine("PROGRAM COMPLETE");
