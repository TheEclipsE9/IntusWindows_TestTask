using MyApp.Domain.Entities;

namespace MyApp.Domain.Contracts.Application
{
    public interface ISubElementService
    {
        SubElement Get(int id);

        void Create(SubElement subElement);

        void Update(int id, SubElement subElement);

        void Delete(int id);
    }
}
