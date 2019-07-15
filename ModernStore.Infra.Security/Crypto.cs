﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ModernStore.Infra.Security
{
    public static class Crypto
    {
        #region Consts
        /// <summary>
        /// Change this Inputkey GUID with a new GUID when you use this code in your own program !!!
        /// Keep this inputkey very safe and prevent someone from decoding it some way !!!
        /// </summary>
        internal const string Inputkey = "<WMK';YD+#v]3}BO2!c/x[WFK[,^Lu#?_M/\"{Zz/J6dODR+8??ZCnB'di]\"[FkR";
        #endregion


        #region Encryption
        /// <summary>
        /// Encrypt the given text and give the byte array back as a BASE64 string
        /// </summary>
        /// <param name="text">The text to encrypt</param>
        /// <param name="salt">The pasword salt</param>
        /// <returns>The encrypted text</returns>
        public static string Encrypt(string text, string salt)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");

            var aesAlg = GenerateSalt(salt);

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            var msEncrypt = new MemoryStream();

            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (var swEncrypt = new StreamWriter(csEncrypt))
                swEncrypt.Write(text);

            return Convert.ToBase64String(msEncrypt.ToArray());
        }
        #endregion

        #region Decrypt
        /// <summary>
        /// Checks if a string is base64 encoded
        /// </summary>
        /// <param name="base64String">The base64 encoded string</param>
        /// <returns></returns>
        private static bool IsBase64String(string base64String)
        {
            base64String = base64String.Trim();

            return (base64String.Length % 4 == 0) &&
                    Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        /// <summary>
        /// Decrypts the given text
        /// </summary>
        /// <param name="cipherText">The encrypted BASE64 text</param>
        /// <param name="salt">The pasword salt</param>
        /// <returns>De gedecrypte text</returns>
        public static string Decrypt(string cipherText, string salt)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");

            if (!IsBase64String(cipherText))
                throw new Exception("The cipherText input parameter is not base64 encoded");

            var aesAlg = GenerateSalt(salt);
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            var cipher = Convert.FromBase64String(cipherText);

            using (var msDecrypt = new MemoryStream(cipher))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (var srDecrypt = new StreamReader(csDecrypt))
                return srDecrypt.ReadToEnd();
        }
        #endregion

        public static string RandomString(int size)
        {
            var chars = "abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVXYZ0123456789!@#$%¨&*()_-+'\"'+=§`´{[ªçÇ^~}]º<,>.;:?/°".ToCharArray();

            byte[] data = new byte[size];

            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }

            StringBuilder result = new StringBuilder(size);

            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        #region NewRijndaelManaged
        /// <summary>
        /// Create a new RijndaelManaged class and initialize it
        /// </summary>
        /// <param name="salt">The pasword salt</param>
        /// <returns></returns>
        private static RijndaelManaged GenerateSalt(string salt)
        {
            if (salt == null) throw new ArgumentNullException("salt");
            var saltBytes = Encoding.ASCII.GetBytes(salt);
            var key = new Rfc2898DeriveBytes(Inputkey, saltBytes);

            var aesAlg = new RijndaelManaged();
            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
            aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);
            aesAlg.Mode = CipherMode.CBC;

            return aesAlg;
        }

        #endregion
    }
}
