using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services.Interfaces;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Handlers
{
    public class AuthenticationCustomerHandler : Notifiable, 
        ICommandHandler<AuthenticationCustomerCommand, AuthenticatedCustomerCommandResult>
    {
        private readonly IUserService userService;

        public AuthenticationCustomerHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public AuthenticatedCustomerCommandResult Handle(AuthenticationCustomerCommand command)
        {
            var email = new Email(command.Email);

            var authenticated = userService.Authenticate(email, command.Password);

            return new AuthenticatedCustomerCommandResult(this.IsValid());
        }
    }
}
