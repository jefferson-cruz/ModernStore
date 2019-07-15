
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Inputs
{
    public class AuthenticationCustomerCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
