using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Data.Contexts;
using System;

namespace ModernStore.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModernStoreContext context;

        public ProductRepository(ModernStoreContext context)
        {
            this.context = context;
        }

        public Product GetById(Guid id)
        {
            return context.Set<Product>().Find(id);
        }
    }
}
