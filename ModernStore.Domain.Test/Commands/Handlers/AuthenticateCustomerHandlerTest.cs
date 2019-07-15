using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services.Interfaces;
using ModernStore.Domain.Test.Utils;
using ModernStore.Infra.Common.Email;
using ModernStore.Infra.Data.Contexts;
using ModernStore.Infra.Data.Repositories;
using ModernStore.Infra.Security;

namespace ModernStore.Domain.Test.Commands.Handlers
{
    [TestClass]
    public class AuthenticateCustomerHandlerTest
    {
        private ModernStoreContext context;
        private ICustomerRepository customerRepository;
        private IUserRepository userRepository;

        private ICryptoService passwordService;
        private IUserService userService;
        private IEmailService emailService;
        private CustomerCommandHandler customerHandler;
        private AuthenticationCustomerHandler authtenticateHandler;

        [TestInitialize]
        public void Initialize()
        {
            this.context = new ModernStoreContext();
            this.customerRepository = new CustomerRepository(context);
            this.userRepository = new UserRepository(context);
            this.passwordService = new CryptoService();
            this.emailService = new SendGridEmailService();
            this.customerHandler = new CustomerCommandHandler(customerRepository, userService, emailService);
            //this.authtenticateHandler = new AuthenticationCustomerHandler(userRepository);
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
                    Password = "12345678",
                }
            };

            var result = customerHandler.Handle(command);

            if (customerHandler.IsValid())
                context.SaveChanges();

            var autheticateCustomerCommand = new AuthenticationCustomerCommand
            {
                Email = command.User.Login,
                Password = command.User.Password
            };

            var response = authtenticateHandler.Handle(autheticateCustomerCommand);

            Assert.IsTrue(response.Authenticated);
        }
    }
}
