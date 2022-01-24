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
    }
}
