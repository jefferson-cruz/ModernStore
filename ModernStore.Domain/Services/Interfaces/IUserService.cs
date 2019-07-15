using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ModernStore.Domain.Services.Interfaces
{
    public interface IUserService
    {
        IReadOnlyCollection<Notification> Notifications { get; }

        bool Authenticate(Email email, string password);

        CryptoPassword CreatePassword(string value);

        User Register(Guid customerId, string email, string password);

        
    }
}
