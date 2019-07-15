using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Data.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable(nameof(Customer));

            HasKey(x => x.Id);

            Property(x => x.Id);
            Property(x => x.Name.FirstName);
            Property(x => x.Name.LastName);
            Property(x => x.BirthDate).HasColumnType("date");
            Property(x => x.Document.Number);
            Property(x => x.CreatedDate).HasColumnType("datetime");
        }
    }
}
