using MyApp.Domain.Entities;

namespace MyApp.Domain.Contracts.Application
{
    public interface IWindowService
    {
        Window Get(int id);

        void Create(Window window);

        void Update(int id, Window window);

        void Delete(int id);
    }
}
