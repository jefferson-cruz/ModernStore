using System;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class UserCryptoPassword : Entity
    {
        protected UserCryptoPassword()
        {

        }

        public UserCryptoPassword(User user, string salt)
        {
            Id = user.Id;
            Salt = salt;
        }

        public Guid Id { get; private set; }
        public User User { get; private set; }
        public string Salt { get; private set; }
    }
}
