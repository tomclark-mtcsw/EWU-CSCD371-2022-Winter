using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    // Underscores are allowed in test methods
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "<Pending>")]
    public class JesterTests
    {
        [TestMethod]
        public void GetJoke_ReturnsString_Success()
        {
            // Arrange
            Jester jester = new Jester();

            // Act
            string joke = jester.GetJoke();

            // Assert
            Assert.AreEqual<string>("System.String", joke.GetType().ToString());
        }

        [TestMethod]
        public void IsChuckNorrisJoke_WithChuckNorrisInString_ReturnsTrue()
        {
            string joke = "This has Chuck Norris in it";
            bool result = Jester.IsChuckNorrisJoke(joke);
            Assert.AreEqual<bool>(true, result);
        }

        [TestMethod]
        public void IsChuckNorrisJoke_WithoutChuckNorrisInString_ReturnsFalse()
        {
            string joke = "This has Arnold Schwarzenegger in it";
            bool result = Jester.IsChuckNorrisJoke(joke);
            Assert.AreEqual<bool>(false, result);
        }

        [TestMethod]
        public void TellJoke_DisplaysJoke_Success()
        {
            // Arrange
            Mock<IJokeOutput> mock = new();
            mock.Setup(x => x.OutputText(It.IsAny<string>()));
            Jester jester = new Jester();

            // Act
            bool result = jester.TellJoke();

            // Assert
            Assert.AreEqual<bool>(true, result);
        }

        [TestMethod]
        public void DisplayJoke_WithEmptyJoke_DisplaysErrorString()
        {
            // Arrange
            Mock<IJokeOutput> mock = new();
            mock.Setup(x => x.OutputText(It.IsAny<string>()));
            Jester jester = new Jester();

            // Act
            bool result = jester.DisplayJoke("");

            // Assert
            Assert.AreEqual<bool>(false,result);
        }

        [TestMethod]
        public void DisplayJoke_WithJoke_DisplaysJoke()
        {
            // Arrange
            Mock<IJokeOutput> mock = new();
            mock.Setup(x => x.OutputText(It.IsAny<string>()));
            Jester jester = new Jester();

            // Act
            bool result = jester.DisplayJoke("test joke");

            // Assert
            Assert.AreEqual<bool>(true, result);
        }
    }
}
