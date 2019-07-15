using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Result;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Resources;
using ModernStore.Domain.Services;
using ModernStore.Domain.Services.Interfaces;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Handlers
{
    public class CustomerCommandHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand, RegisterCustomerCommandResult>,
        ICommandHandler<UpdateCustomerCommand, UpdateCustomerCommandResult>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUserService userService;
        private readonly IEmailService emailService;

        public CustomerCommandHandler(
            ICustomerRepository customerRepository,
            IUserService userService,
            IEmailService emailService)
        {
            this.customerRepository = customerRepository;
            this.userService = userService;
            this.emailService = emailService;
        }

        public RegisterCustomerCommandResult Handle(CreateCustomerCommand command)
        {
            var customer = new Customer(command.FirstName, command.LastName, command.Document);

            AddNotifications(customer.Notifications);

            if (IsValid())
            {
                customerRepository.Insert(customer);

                var user = userService.Register(customer.Id, command.Email, command.User.Password);

                AddNotifications(user.Notifications);

                if (IsValid())
                {
                    var customerName = customer.Name.ToString();

                    emailService.Send(
                        customer.Name.ToString(),
                        user.Email.Address,
                        string.Format(EmailTemplates.WelcomeEmailTitle, customerName),
                        string.Format(EmailTemplates.WelcomeEmailBody, customerName));

                    return new RegisterCustomerCommandResult(customer.Id, customerName);
                }
            }

            return default(RegisterCustomerCommandResult);
        }

        public UpdateCustomerCommandResult Handle(UpdateCustomerCommand command)
        {
            var customer = customerRepository.GetById(command.Id);

            if (customer == null)
            {
                AddNotification("Customer", "Customer not found");

                return null;
            }

            customer.Update(command.FirstName, command.LastName, command.BirthDate);

            AddNotifications(customer.Notifications);

            if (customer.IsValid())
                customerRepository.Update(customer);

            return new UpdateCustomerCommandResult(customer.Id, customer.Name.ToString());
        }
    }
}
