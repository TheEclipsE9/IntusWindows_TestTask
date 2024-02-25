using MyApp.Domain.Contracts.DTOs.SubElement;

namespace MyApp.Domain.Contracts.Application
{
    public interface ISubElementService
    {
        SubElementDTO Get(int id);
        List<SubElementDTO> GetAllByWindowId(int windowId);

        SubElementDTO Create(CreateSubElementDTO subElement);

        SubElementDTO Update(int id, UpdateSubElementDTO subElement);

        void Delete(int id);
    }
}
