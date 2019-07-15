using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Repositories
{
    public interface IUserRepository
    {
        void Insert(User user);

        void Update(User user);

        void SaveSaltPassword(UserCryptoPassword userCryptoPassword);
        string GetSaltPassword(User user);

        User GetByEmail(Email email);
    }
}
