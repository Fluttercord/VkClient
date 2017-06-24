using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VkClient.Test
{
    [TestClass]
    public class ClientTests
    {
        private const string _testUserId = "urId";

        [TestMethod]
        public void GetUserTest()
        {
            var instance = new Client(string.Empty);
            var user = instance.GetUser(_testUserId).GetAwaiter().GetResult();
            Assert.IsNotNull(user);
            Assert.IsNotNull(user.FirstName);
            Assert.IsNotNull(user.LastName);
        }

        [TestMethod]
        public void GetUserAudiosTest()
        {
            const string token = "UrToken";
            var instance = new Client(token);
            var audios = instance.GetUserAudios(_testUserId).GetAwaiter().GetResult();
            Assert.IsNotNull(audios);
            Assert.IsTrue(audios.Length != 0);
        }
    }
}
