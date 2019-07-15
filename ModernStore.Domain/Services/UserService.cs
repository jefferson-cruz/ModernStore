using FluentValidator;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services.Interfaces;
using ModernStore.Domain.ValueObjects;
using System;

namespace ModernStore.Domain.Services
{
    public class UserService : Notifiable, IUserService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUserRepository userRepository;
        private readonly ICryptoService cryptoService;

        public UserService(
            ICustomerRepository customerRepository,
            IUserRepository userRepository,
            ICryptoService cryptoService)
        {
            this.customerRepository = customerRepository;
            this.userRepository = userRepository;
            this.cryptoService = cryptoService;
        }

        public bool Authenticate(Email email, string password)
        {
            if (!email.IsValid())
            {
                AddNotifications(email.Notifications);
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                AddNotification("User", "Password is required");
                return false;
            }

            var user = userRepository.GetByEmail(email);

            if (user == null)
            {
                AddNotification("User", "Your account is wrong. Check your email informed.");
                return false;
            }

            var salt = userRepository.GetSaltPassword(user);

            return PasswordAreEquals(password, new CryptoPassword(user.Password.Value, salt));
        }

        private bool PasswordAreEquals(string password, CryptoPassword cryptoPassword)
        {
            return cryptoService.AreEquals(password, cryptoPassword.Password, cryptoPassword.Salt);
        }

        public CryptoPassword CreatePassword(string value)
        {
            if (string.IsNullOrEmpty(value))
                return new CryptoPassword(null, null);

            var salt = cryptoService.GetCryptoString(size: 32);

            return new CryptoPassword(cryptoService.Encrypt(value, salt), salt);
        }

        public User Register(Guid customerId, string email, string password)
        {
            var customer = customerRepository.GetById(customerId);

            var cryptoPassword = CreatePassword(password);

            var user = new User(customer, new Email(email), new Password(cryptoPassword.Password));

            if (user.IsValid())
            {
                userRepository.Insert(user);
                userRepository.SaveSaltPassword(new UserCryptoPassword(user, cryptoPassword.Salt));
            }

            return user;
        }

    }
}
