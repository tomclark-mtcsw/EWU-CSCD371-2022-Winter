using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        //public void MethodName_StateUnderTest_ExpectedBehavior()
        //{
            // Arrange

            // Act

            // Assert
        //}

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
    }
}
