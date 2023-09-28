using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models.Interfaces;
using TestTask.Repositories.Interfaces;

namespace TestTask.Repositories
{
    public class BaseReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public BaseReadOnlyRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        protected ApplicationDbContext Context { get; }

        protected DbSet<TEntity> DbSet { get; }

        public IQueryable<TEntity> GetAsQueryable(bool noTracking = true)
        {
            return noTracking ? DbSet.AsNoTracking().AsQueryable() : DbSet.AsQueryable();
        }
    }
}