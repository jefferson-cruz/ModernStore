using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Data.Mappings
{
    public class UserCryptoPasswordMap : EntityTypeConfiguration<UserCryptoPassword>
    {
        public UserCryptoPasswordMap()
        {
            ToTable(nameof(UserCryptoPassword));

            HasKey(x => x.Id);

            Property(x => x.Id);
            Property(x => x.Salt).HasMaxLength(250);

            HasRequired(x => x.User)
                .WithOptional(x => x.EncryptedPassword);
        }
    }
}
