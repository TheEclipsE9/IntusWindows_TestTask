using MyApp.Domain.Entities;

namespace MyApp.Domain.Contracts.Application
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();

        Order Get(int id);

        void Create(Order order);

        void Delete(int id);
    }
}
