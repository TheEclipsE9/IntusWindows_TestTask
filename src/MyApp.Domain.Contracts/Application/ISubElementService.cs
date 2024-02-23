using MyApp.Domain.Entities;

namespace MyApp.Domain.Contracts.Application
{
    public interface ISubElementService
    {
        SubElement Get(int id);

        void Create(SubElement window);

        void Update(int id, SubElement window);

        void Delete(int id);
    }
}
