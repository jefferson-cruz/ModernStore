using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetById(Guid id);
    }
}
