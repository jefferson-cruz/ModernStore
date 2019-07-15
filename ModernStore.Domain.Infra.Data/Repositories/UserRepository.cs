using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using ModernStore.Infra.Data.Contexts;
using System.Data.Entity;
using System.Linq;

namespace ModernStore.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ModernStoreContext context;

        public UserRepository(ModernStoreContext context)
        {
            this.context = context;
        }

        public User GetByEmail(Email email)
        {
            return this.context.Set<User>().FirstOrDefault(x => x.Email.Address == email.Address);
        }
        
        public string GetSaltPassword(User user)
        {
            var salt = this.context.Set<UserCryptoPassword>()
                .Where(x => x.Id == user.Id)
                .Select(x => x.Salt)
                .FirstOrDefault();

            return salt;
        }

        public void Insert(User user)
        {
            this.context.Set<User>().Add(user);
        }

        public void SaveSaltPassword(UserCryptoPassword userCryptoPassword)
        {
            this.context.Set<UserCryptoPassword>().Add(userCryptoPassword);
        }

        public void Update(User user)
        {
            this.context.Entry(user).State = EntityState.Modified;
        }
    }
}
