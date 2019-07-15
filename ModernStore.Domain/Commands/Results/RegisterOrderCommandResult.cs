using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Results
{
    public class RegisterOrderCommandResult : ICommandResult
    {
        public RegisterOrderCommandResult(string number)
        {
            Number = number ;
        }
        public string Number { get; }
    }
}
