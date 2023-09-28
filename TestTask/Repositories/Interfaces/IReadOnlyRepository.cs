using TestTask.Models.Interfaces;

namespace TestTask.Repositories.Interfaces
{
    public interface IReadOnlyRepository<TEntity, in TKey> : IRepository
        where TEntity : IEntity<TKey>
    {
        IQueryable<TEntity> GetAsQueryable(bool noTracking = true);
    }
}