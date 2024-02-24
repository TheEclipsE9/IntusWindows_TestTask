using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Contracts.Application;
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

        public Window Get(int id)
        {
            var window = _dbContext.Windows.SingleOrDefault(x => x.Id == id);
            if (window is null)
            {
                throw new ArgumentException();
            }

            return window;
        }

        public void Create(Window window)
        {
            _dbContext.Windows.Add(window);

            _dbContext.SaveChanges();
        }

        public void Update(int id, Window window)
        {
            var dbWindow = _dbContext.Windows.SingleOrDefault(x => x.Id == id);
            if (dbWindow is null)
            {
                throw new ArgumentException();
            }

            dbWindow.Name = window.Name;
            dbWindow.Quantity = window.Quantity;

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
