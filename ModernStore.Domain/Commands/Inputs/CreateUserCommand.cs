using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Inputs
{
    public class CreateUserCommand : ICommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
