using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Results
{
    public class AuthenticatedCustomerCommandResult : ICommandResult
    {
        public AuthenticatedCustomerCommandResult(bool authenticated)
        {
            Authenticated = authenticated;
        }

        public bool Authenticated { get; }
    }
}
