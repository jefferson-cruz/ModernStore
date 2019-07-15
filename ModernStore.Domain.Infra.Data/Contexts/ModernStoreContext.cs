using ModernStore.Infra.Data.Contexts.Enums;
using ModernStore.Infra.Data.Contexts.Interfaces;
using System.Data.Entity;

namespace ModernStore.Infra.Data.Contexts
{
    public class ModernStoreContext : DbContext
    {
        public ModernStoreContext() : base(ConnectionManager.GetConnectionString(ConnectionString.ModernStore))
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            //base.OnModelCreating(modelBuilder);
        }
    }
}
