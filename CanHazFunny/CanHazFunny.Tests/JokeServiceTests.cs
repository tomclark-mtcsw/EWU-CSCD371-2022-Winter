using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanHazFunny.Tests
{
    [TestClass]
    // Underscores are allowed in test methods
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "<Pending>")]
    public class JokeServiceTests
    {
        [TestMethod]
        public void GetJoke_ReturnsString_Success()
        {
            // Arrange
            JokeService jokeService = new JokeService();

            // Act
            string joke = jokeService.GetJoke();

            // Assert
            Assert.AreEqual<string>("System.String", joke.GetType().ToString());
        }
    }
}
