using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Contracts.Application;
using MyApp.Domain.Contracts.DTOs.Window;
using MyApp.Domain.Contracts.Infrastructure;
using MyApp.Domain.Entities;

namespace MyApp.Application.Services
{
    public sealed class WindowService : IWindowService
    {
        private readonly IAppDbContext _dbContext;

        public WindowService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public WindowDTO Get(int id)
        {
            var window = _dbContext.Windows.SingleOrDefault(x => x.Id == id);
            if (window is null)
            {
                throw new ArgumentException();
            }

            var windowDTO = new WindowDTO()
            {
                Id = window.Id,
                Name = window.Name,
                Quantity = window.Quantity,
            };

            return windowDTO;
        }

        public List<WindowDTO> GetAllByOrderId(int orderId)
        {
            var windows = _dbContext.Windows
                .Where(x => x.OrderId == orderId)
                .Select(x => new WindowDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Quantity = x.Quantity,
                })
                .ToList();

            return windows;
        }

        public WindowDTO Create(CreateWindowDTO windowDTO)
        {
            var order = _dbContext.Orders.SingleOrDefault(x => x.Id == windowDTO.OrderId);
            if (order is null)
            {
                throw new ArgumentException();
            }

            var window = new Window()
            {
                Name = windowDTO.Name,
                Quantity = windowDTO.Quantity,
                OrderId = windowDTO.OrderId,
            };

            _dbContext.Windows.Add(window);

            _dbContext.SaveChanges();

            return new WindowDTO
            {
                Id = window.Id,
                Name = window.Name,
                Quantity = window.Quantity,
            };
        }

        public void Update(int id, UpdateWindowDTO windowDTO)
        {
            var window = _dbContext.Windows.SingleOrDefault(x => x.Id == id);
            if (window is null)
            {
                throw new ArgumentException();
            }

            window.Name = windowDTO.Name;
            window.Quantity = windowDTO.Quantity;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var window = _dbContext.Windows.SingleOrDefault(x => x.Id == id);
            if (window is null)
            {
                return;
            }

            _dbContext.Windows.Remove(window);

            _dbContext.SaveChanges();
        }
    }
}
