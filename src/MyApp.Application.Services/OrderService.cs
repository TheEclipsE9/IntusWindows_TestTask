using MyApp.Domain.Contracts.Application;
using MyApp.Domain.Contracts.Infrastructure;
using MyApp.Domain.Entities;

namespace MyApp.Application.Services
{
    public sealed class OrderService : IOrderService
    {
        private readonly IAppDbContext _dbContext;

        public OrderService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order Get(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == id);
            if (order is null)
            {
                throw new ArgumentException();
            }

            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public void Create(Order order)
        {
            _dbContext.Orders.Add(order);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == id);
            if (order is null)
            {
                return;
            }
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }
    }
}
