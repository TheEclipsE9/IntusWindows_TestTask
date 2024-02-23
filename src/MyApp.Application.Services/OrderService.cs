using MyApp.Domain.Contracts.Application;
using MyApp.Domain.Entities;

namespace MyApp.Application.Services
{
    internal sealed class OrderService : IOrderService
    {
        private ICollection<Order> _orders = new List<Order>
        {
            new Order
            {
                Id = 1, Name = "Test 1", State = "NY", Windows = Enumerable.Empty<Window>().ToList()
            },
            new Order
            {
                Id = 2, Name = "Test 2", State = "WS", Windows = new List<Window>
                {
                    new Window { Id = 1, Name = "Window", Quantity = 3, SubElements = Enumerable.Empty<SubElement>().ToList(), OrderId = 1 },
                }
            }
        };

        public void Create(Order order)
        {
            _orders.Add(order);
        }

        public void Delete(int id)
        {
            var order = _orders.SingleOrDefault(x => x.Id == id);
            if (order is null)
            {
                return;
            }
            _orders.Remove(order);
        }

        public Order Get(int id)
        {
            var order = _orders.SingleOrDefault(x => x.Id == id);
            if (order is null)
            {
                throw new ArgumentException();
            }
            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }
    }
}
