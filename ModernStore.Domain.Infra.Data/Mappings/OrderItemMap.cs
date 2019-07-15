using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Data.Mappings
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            ToTable(nameof(OrderItem));

            HasKey(x => x.Id);


            Property(x => x.Price);
            Property(x => x.Quantity);
        }
    }
}
