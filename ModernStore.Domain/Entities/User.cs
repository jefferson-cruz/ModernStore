using FluentValidator;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }

        public User(Customer customer, Email email, Password password)
        {
            Id = customer.Id;
            Customer = customer;
            Email = email;
            Password = password;

            new ValidationContract<User>(this)
                .IsNotNull(Customer, "Customer can't be null");

            AddNotifications(Email.Notifications);
            AddNotifications(Password.Notifications);
        }

        public Guid Id { get; private set; }
        public Customer Customer { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public UserCryptoPassword EncryptedPassword {get;set;}
        public bool Active { get; private set; }
    }
}
