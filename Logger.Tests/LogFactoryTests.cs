using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_WithEmptyFilePath_ReturnsNull()
        {
            // Arrange
            var logFactory = new LogFactory();

            // Act
            var logger = logFactory.CreateLogger(nameof(LogFactoryTests));

            // Assert
            Assert.IsNull(logger);
        }

        [TestMethod]
        public void CreateLogger_WithFilePath_ReturnsFileLoggerObject()
        {
            // Arrange
            var logFactory = new LogFactory();
            logFactory.ConfigureFileLogger("MyTestPath");

            // Act
            var logger = logFactory.CreateLogger(nameof(LogFactoryTests));

            // Assert
            Assert.AreEqual("FileLogger",logger.GetType().Name);
        }
    }
}
