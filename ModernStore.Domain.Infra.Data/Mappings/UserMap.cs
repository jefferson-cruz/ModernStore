using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(nameof(User));

            HasKey(x => x.Id);

            Property(x => x.Id);
            Property(x => x.Email.Address).HasMaxLength(200);
            Property(x => x.Password.Value).HasMaxLength(250);
            Property(x => x.Active);

            HasRequired(x => x.Customer)
                .WithOptional(x => x.User);
        }
    }
}
