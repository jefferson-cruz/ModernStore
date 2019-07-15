using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(Guid id);
        void Insert(Customer customer);
        void Update(Customer customer);
        bool VerifyIfDocumentExists(string documentNumber);
        bool VerifyIfDocumentExists(Guid id, string documentNumber);
    }
}
