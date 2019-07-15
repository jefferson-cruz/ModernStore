using ModernStore.Domain.Services;
using ModernStore.Domain.Services.Interfaces;

namespace ModernStore.Infra.Security
{
    public class CryptoService : Service, ICryptoService
    {
        public bool AreEquals(string plainText, string encryptedValue, string salt)
        {
            return plainText.Equals(Crypto.Decrypt(encryptedValue, salt));
        }

        public string Encrypt(string value, string salt)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return Crypto.Encrypt(value, salt);
        }

        public string GetCryptoString(int size)
        {
            return Crypto.RandomString(size);
        }
    }
}
