using MyApp.Domain.Contracts.Application;
using MyApp.Domain.Contracts.DTOs.Order;
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

        public OrderDTO Get(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == id);
            if (order is null)
            {
                throw new ArgumentException();
            }

            var orderDTO = new OrderDTO()
            {
                Id = order.Id,
                Name = order.Name,
                State = order.State,
            };

            return orderDTO;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            var orders = _dbContext.Orders
                .Select(order=> new OrderDTO
                {
                    Id= order.Id,
                    Name = order.Name,
                    State = order.State,
                });

            return orders;
        }

        public OrderDTO Create(CreateOrderDTO orderDTO)
        {
            var order = new Order()
            {
                Name = orderDTO.Name,
                State = orderDTO.State,
            };

            _dbContext.Orders.Add(order);

            _dbContext.SaveChanges();

            return new OrderDTO 
            { 
                Id = order.Id,
                Name = orderDTO.Name,
                State = orderDTO.State,
            };
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
