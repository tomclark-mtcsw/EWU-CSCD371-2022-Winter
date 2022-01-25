using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FileLoggerConstructor_HasNoClassName_ThrowsException()
        {
            // Arrange
            FileLogger logger = new FileLogger();

            // Act
            logger.Log(LogLevel.Error, "Test Message");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Log_HasNoLogFilePath_ThrowsException()
        {
            // Arrange
            FileLogger logger = new FileLogger()
            {
                ClassName = "FileLoggerTests"
            };

            // Act
            logger.Log(LogLevel.Error, "Test Message");

            // Assert
        }

        [TestMethod]
        public void FileLoggerConstructor_HasClassName_CreatesFileLoggerObject()
        {
            // Arrange

            // Act
            FileLogger logger = new FileLogger(nameof(FileLoggerTests));

            // Assert
            Assert.AreEqual("FileLogger", logger.GetType().Name);
        }

        [TestMethod]
        public void Log_WithLogMessage_SuccessfullyStoresMessage()
        {
            // Arrange
            var logger = new TestLogger("TestFilePath");

            // Act
            logger.Log(LogLevel.Error, "My Message");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("My Message", logger.LoggedMessages[0].Message);
        }

        public class TestLogger : FileLogger
        {
            public TestLogger(string filePath)
            {
                LogFilePath = filePath;
            }

            public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

            public override void UpdateLog(LogLevel logLevel, string message, string filePath)
            {
                LoggedMessages.Add((logLevel, message));
            }
        }
    }
}
