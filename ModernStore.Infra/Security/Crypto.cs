using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ModernStore.Infra.Security
{
    public class Crypto
    {
        public static class Config
        {
            // set permutations
            public const string strPermutation = "f4dEStf6xdVyW0fB0SzY|tVNFswlAkOAFiuvwtBeK+wpMliCYXTFZnhdmlhIUR";
            public const int bytePermutation1 = 0x19;
            public const int bytePermutation2 = 0x59;
            public const int bytePermutation3 = 0x17;
            public const int bytePermutation4 = 0x41;
        }

        public static string Encrypt(string strData)
        {

            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
        }

        public static string Decrypt(string strData)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
        }

        public static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(Config.strPermutation,
            new byte[] { Config.bytePermutation1,
                         Config.bytePermutation2,
                         Config.bytePermutation3,
                         Config.bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }

        // decrypt
        public static byte[] Decrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(Config.strPermutation,
            new byte[] { Config.bytePermutation1,
                         Config.bytePermutation2,
                         Config.bytePermutation3,
                         Config.bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }
    }
}
