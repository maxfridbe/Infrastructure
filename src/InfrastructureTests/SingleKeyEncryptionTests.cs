using System;
using System.Security.Cryptography;
using Infrastructure.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfrastructureTests
{
    [TestClass]
    public class SingleKeyEncryptionTests
    {
        private class keygetter : ISingleKeyStore
        {
            public string GetKey()
            {
                return "AABBCC22AABB2234567789934748449";
            }

            public void SetKey(string key)
            {

            }
        }

        private class unsetStore : ISingleKeyStore
        {
            private string _key;

            public string GetKey()
            {
                return _key;
            }

            public void SetKey(string key)
            {
                _key = key;
                Assert.IsTrue(!string.IsNullOrWhiteSpace(key));
            }
        }
        [TestMethod]
        public void TestEncrypt()
        {
            //arrange
            var kes = new SingleKeyEncryptionService(new keygetter());

            //act
            var res = kes.EncryptString("HelloWorld");

            //assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(res));
        }

        [TestMethod]
        public void TestEncryptDecrypt_success()
        {
            //arrange
            var kes = new SingleKeyEncryptionService(new keygetter());
            var data = "HelloWorldtesting12324 aldfjadslfja sdfasdlfkjasdifa dsfadsfasd";
            //act
            var res = kes.EncryptString(data);
            var dec = kes.DecryptString(res);

            //assert
            Assert.AreEqual(data, dec);
        }

        [TestMethod]
        public void TestEncryptDecrypt_success2()
        {
            //arrange
            var kes = new SingleKeyEncryptionService(new keygetter());
            var data = "HelloWorld";
            var kes2 = new SingleKeyEncryptionService(new keygetter());

            //act
            var res = kes.EncryptString(data);
            var dec = kes2.DecryptString(res);

            //assert
            Assert.AreEqual(data, dec);
        }

        [TestMethod]
        public void TestEncryptDecrypt_failure()
        {
            //arrange
            var kes = new SingleKeyEncryptionService(new keygetter());
            var data = "HelloWorld";
            var kes2 = new SingleKeyEncryptionService(new keygetter());

            //act
            var res = kes.EncryptString(data);
            var dec = kes2.DecryptString(res);

            //assert
            Assert.AreEqual(data, dec);
        }
        [TestMethod]
        public void TestEncryptDecrypt_unset()
        {
            //arrange
            var kes = new SingleKeyEncryptionService(new unsetStore());

            //act

            //assert
        }
    }
}
