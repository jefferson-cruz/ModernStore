using System;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services;
using ModernStore.Domain.Services.Interfaces;
using ModernStore.Domain.Test.Utils;
using ModernStore.Infra.Common.Email;
using ModernStore.Infra.Data.Contexts;
using ModernStore.Infra.Data.Repositories;
using ModernStore.Infra.Security;

namespace ModernStore.Domain.Test.Commands.Handlers
{
    [TestClass]
    public class CustomerCommandHandlerTest
    {
        private ModernStoreContext context;
        private ICustomerRepository customerRepository;
        private IUserRepository userRepository;

        private ICryptoService passwordService;
        private IUserService userService;
        private IEmailService emailService;
        private CustomerCommandHandler handler;

        [TestInitialize]
        public void Initialize()
        {
            this.context = new ModernStoreContext();
            this.customerRepository = new CustomerRepository(context);
            this.userRepository = new UserRepository(context);

            this.passwordService = new CryptoService();
            this.userService = new UserService(customerRepository, userRepository, passwordService);
            this.emailService = new SendGridEmailService();
            this.handler = new CustomerCommandHandler(customerRepository, userService, emailService);
        }

        [TestMethod]
        public void CreateCustomer()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Document = CpfGenerator.Gerar(),
                Email = Faker.Internet.Email(),
                User = new CreateUserCommand
                {
                    Login = Faker.Internet.UserName(),
                    Password = "1234567",
                }
            };

            var response = handler.Handle(command);

            if (handler.IsValid())
                context.SaveChanges();
            else
            {
                var sb = new StringBuilder();

                foreach (var notification in handler.Notifications)
                {
                    sb.AppendLine($"{notification.Property} {notification.Message}");
                }

                try
                {
                    if (sb.Length > 0)
                        throw new Exception(sb.ToString());

                }
                catch(Exception ex)
                {
                    Assert.Fail(ex.Message);
                }

            }
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            var customers = customerRepository.GetAll().ToArray();

            var customer = customers[new Random().Next(0, customers.Length - 1)];
            
            var command = new UpdateCustomerCommand
            {
                Id = customer.Id,
                FirstName = "Jefferson",
                LastName = "Pereira da Cruz",
                BirthDate = new DateTime(1988, 09, 29),
            };

            handler.Handle(command);

            if(handler.IsValid())
                context.SaveChanges();

            Assert.IsTrue(handler.IsValid());
        }
    }
}
