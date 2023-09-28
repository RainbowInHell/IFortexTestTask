using TestTask.Data;
using TestTask.Repositories.Interfaces;
using TestTask.Repositories;
using TestTask.Models;
using TestTask.UnitOfWork.Interfaces;
using System.Data;

namespace TestTask.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;

        private bool isDisposed;

        private IReadOnlyRepository<Order, int> orderReposisory;

        private IReadOnlyRepository<User, int> userReposisory;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            isDisposed = false;
        }

        public IReadOnlyRepository<Order, int> OrderRepository => orderReposisory ?? (orderReposisory = new BaseReadOnlyRepository<Order, int>(context));

        public IReadOnlyRepository<User, int> UserRepository => userReposisory ?? (userReposisory = new BaseReadOnlyRepository<User, int>(context));

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    context.Dispose();
                    context = null;
                }
            }

            isDisposed = true;
        }
    }
}