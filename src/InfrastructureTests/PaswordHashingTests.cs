using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfrastructureTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class PaswordHashingTests
    {


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestHashing()
        {

            //arrange
            var provider = new PBKDF2PasswordHashProvider();

            //act
            var hash = provider.CreatePasswordHash("password");

            //assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(hash));
        }

        [TestMethod]
        public void TestHashingUnhashing_FAIL()
        {

            //arrange
            var provider = new PBKDF2PasswordHashProvider();
            var hash = provider.CreatePasswordHash("password");
            //act
           var valid = provider.ValidatePassword("a", hash);

            //assert
            Assert.IsFalse(valid);
        }

        [TestMethod]
        public void TestHashingUnhashing_PASS()
        {

            //arrange
            var provider = new PBKDF2PasswordHashProvider();
            var hash = provider.CreatePasswordHash("password");
            //act
            var valid = provider.ValidatePassword("password", hash);

            //assert
            Assert.IsTrue(valid);
        }
    }
}
