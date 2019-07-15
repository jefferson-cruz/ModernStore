using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Data.Mappings
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable(nameof(Order));

            HasKey(x => x.Number);

            Property(x => x.Number);
            Property(x => x.Status);
            Property(x => x.CreateDate);
            //Property(x => x.Customer.Id);
            Property(x => x.DeliveryFee);
            Property(x => x.Discount);

            HasRequired(x => x.Customer);

            HasMany(x => x.Items).WithRequired();
        }
    }
}
