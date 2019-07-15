using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Infra.Security;
using System;

namespace ModernStore.Domain.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Encrypt()
        {
            var password = "123456789";

            var salt = Crypto.RandomString(new Random().Next(10, 50));

            var encrypted = Crypto.Encrypt(password, salt);

            var decrypted = Crypto.Decrypt(encrypted, salt);

            Assert.AreEqual(password, decrypted);
        }


        [TestMethod]
        public void Decrypt()
        {
            var salt = "ªEh,cp:%#Fy~iz,O=jlL*}E<u'!o{3'VSaa;dht(^?Cx0v";
            var encrypted = "pc/2Yru2/E//IaWrCYL1TQ==";

            var decrypted = Crypto.Decrypt(encrypted, salt);

            //Assert.AreEqual(password, decrypted);
        }
    }
}
