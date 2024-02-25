using MyApp.Domain.Contracts.DTOs.Order;

namespace MyApp.Domain.Contracts.Application
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAll();

        OrderDTO Get(int id);

        OrderDTO Create(CreateOrderDTO orderDTO);

        void Delete(int id);
    }
}
