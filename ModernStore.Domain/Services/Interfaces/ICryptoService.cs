using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Services.Interfaces
{
    public interface ICryptoService
    {
        string Encrypt(string value, string salt);

        string GetCryptoString(int size);
        bool AreEquals(string plainText, string encryptedValue, string salt);
    }
}
