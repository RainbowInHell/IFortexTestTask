using Microsoft.EntityFrameworkCore;
using System.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.UnitOfWork.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Order?> GetOrder()
        {
            return await unitOfWork.OrderRepository
                .GetAsQueryable()
                .OrderByDescending(x => x.Price)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await unitOfWork.OrderRepository
                .GetAsQueryable()
                .Where(x => x.Quantity > 10)
                .ToListAsync();
        }
    }
}