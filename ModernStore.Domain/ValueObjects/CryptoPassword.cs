namespace ModernStore.Domain.ValueObjects
{
    public class CryptoPassword
    {
        public CryptoPassword(string password, string salt)
        {
            Password = password;
            Salt = salt;
        }

        public string Password { get; }
        public string Salt { get; }
    }
}
