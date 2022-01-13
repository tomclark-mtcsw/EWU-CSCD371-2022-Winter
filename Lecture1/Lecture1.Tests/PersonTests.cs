using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lecture1.Tests
{
    [TestClass]
    public class PersonTests
    {
        Person Person = new();
        string UserName = "";
        string Password = "";

        [TestInitialize]
        public void Initialize()
        {
            Password = "YouKilledMyF@ther!";
            UserName = "Inigo.Montoya";
        }


        [TestMethod]
        public void Login_GivenInvalidPassword_Failure()
        {
            Password = "InvalidPwd";
            bool result = Person.Login(UserName, Password);
            Assert.IsFalse(result);

        }


        [TestMethod]
        public void Login_GivenValidUserNameAndPassword_Success()
        {
            bool success = Person.Login(UserName, Password);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Login_GivenInvalidUsername_Failure()
        {
            UserName = "MarkMichaelis";
            bool result = Person.Login(UserName, Password);
            Assert.IsFalse(result);
        }
    }
}