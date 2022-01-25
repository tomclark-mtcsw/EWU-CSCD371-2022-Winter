﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Error(null, "");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Warning(null, "");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Information(null, "");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Debug(null, "");

            // Assert
        }

        [TestMethod]
        public void Error_WithMessageParams_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

            // Act
            logger.Error("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Error_WithMessageNoParams_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

            // Act
            logger.Error("Plain Message", "");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Plain Message", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Warning_WithMessageParams_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

            // Act
            logger.Warning("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Warning_WithMessageNoParams_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

            // Act
            logger.Warning("Plain Message", "");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Plain Message", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Information_WithMessageParams_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

            // Act
            logger.Information("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Information_WithMessageNoParams_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

            // Act
            logger.Information("Plain Message", "");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Plain Message", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Debug_WithMessageParams_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

            // Act
            logger.Debug("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }

        [TestMethod]
        public void Debug_WithMessageNoParams_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

            // Act
            logger.Debug("Plain Message", "");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Plain Message", logger.LoggedMessages[0].Message);
        }

    }

    public class TestLogger : BaseLogger
    {
        public TestLogger(string className)
        {
            ClassName = className;
        }

        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}