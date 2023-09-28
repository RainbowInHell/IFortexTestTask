using System.Data;
using TestTask.Models;
using TestTask.Repositories.Interfaces;

namespace TestTask.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IReadOnlyRepository<Order, int> OrderRepository { get; }

        IReadOnlyRepository<User, int> UserRepository { get; }
    }
}