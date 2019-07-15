using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Inputs
{
    public class CreateCustomerCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public CreateUserCommand User { get; set; }
    }
}
