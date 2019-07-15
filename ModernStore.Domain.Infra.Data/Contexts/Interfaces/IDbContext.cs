using ModernStore.Shared.Entities;
using System.Data.Entity;

namespace ModernStore.Infra.Data.Contexts.Interfaces
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : Entity;


    }
}
