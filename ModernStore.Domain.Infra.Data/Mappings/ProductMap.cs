using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Data.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(nameof(Product));

            HasKey(x => x.Id);

            Property(x => x.Id);
            Property(x => x.Title);
            Property(x => x.Price);
            Property(x => x.QuantityOnHand);
            Property(x => x.Image);
        }
    }
}
