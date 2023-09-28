using Microsoft.EntityFrameworkCore;
using System.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.UnitOfWork.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<User?> GetUser()
        {
            return await unitOfWork.UserRepository
                .GetAsQueryable()
                .Include(x => x.Orders)
                .OrderByDescending(x => x.Orders.Count)
                .FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await unitOfWork.UserRepository
                .GetAsQueryable()
                .Where(x => x.Status == UserStatus.Inactive)
                .ToListAsync();
        }
    }
}