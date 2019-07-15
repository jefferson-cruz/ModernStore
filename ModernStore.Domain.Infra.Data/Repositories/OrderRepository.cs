using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Data.Contexts;
using System.Data.Entity;
using System.Linq;

namespace ModernStore.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ModernStoreContext context;
        private readonly DbSet<Order> dbSet;

        public OrderRepository(ModernStoreContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Order>();
        }

        public void Save(Order order)
        {
            var register = dbSet.FirstOrDefault(x => x.Number == order.Number);

            if (register == null)
            {
                dbSet.Add(order);

                return;
            }

            context.Entry<Order>(order).State = EntityState.Modified;
        }
    }
}
