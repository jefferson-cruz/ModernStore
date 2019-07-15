using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands.Result
{
    public class UpdateCustomerCommandResult : ICommandResult
    {
        public UpdateCustomerCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }

    }
}
