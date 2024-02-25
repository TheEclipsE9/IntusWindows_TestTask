using MyApp.Domain.Contracts.Application;
using MyApp.Domain.Contracts.DTOs.SubElement;
using MyApp.Domain.Contracts.Infrastructure;
using MyApp.Domain.Entities;

namespace MyApp.Application.Services
{
    public sealed class SubElementService : ISubElementService
    {
        private readonly IAppDbContext _dbContext;

        public SubElementService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SubElementDTO Get(int id)
        {
            var subElement = _dbContext.SubElements.SingleOrDefault(x => x.Id == id);
            if (subElement is null)
            {
                throw new ArgumentException();
            }

            var subElementDTO = new SubElementDTO()
            {
                Id = subElement.Id,
                Type = subElement.Type,
                Width = subElement.Width,
                Height = subElement.Height,
            };

            return subElementDTO;
        }

        public List<SubElementDTO> GetAllByWindowId(int windowId)
        {
            var subElements = _dbContext.SubElements
                .Where(x => x.WindowId == windowId)
                .Select(x => new SubElementDTO()
                {
                    Id = x.Id,
                    Type = x.Type,
                    Width = x.Width,
                    Height = x.Height,
                })
                .ToList();

            return subElements;
        }

        public SubElementDTO Create(CreateSubElementDTO subElementDTO)
        {
            var window = _dbContext.Windows.SingleOrDefault(x => x.Id == subElementDTO.WindowId);
            if (window is null)
            {
                throw new ArgumentException();
            }
            var subElement = new SubElement()
            {
                Type = subElementDTO.Type,
                Width = subElementDTO.Width,
                Height = subElementDTO.Height,
                WindowId = subElementDTO.WindowId
            };

            _dbContext.SubElements.Add(subElement);

            _dbContext.SaveChanges();

            return new SubElementDTO()
            {
                Id = subElement.Id,
                Type = subElementDTO.Type,
                Width = subElementDTO.Width,
                Height = subElementDTO.Height,
            };
        }

        public SubElementDTO Update(int id, UpdateSubElementDTO subElementDTO)
        {
            var subElement = _dbContext.SubElements.SingleOrDefault(x => x.Id == id);
            if (subElement is null)
            {
                throw new ArgumentException();
            }

            subElement.Type = subElementDTO.Type;
            subElement.Width = subElementDTO.Width;
            subElement.Height = subElementDTO.Height;

            _dbContext.SaveChanges();

            return new SubElementDTO
            {
                Id = id,
                Type = subElementDTO.Type,
                Width = subElementDTO.Width,
                Height = subElementDTO.Height,
            };
        }

        public void Delete(int id)
        {
            var subElement = _dbContext.SubElements.SingleOrDefault(x => x.Id == id);
            if (subElement is null)
            {
                return;
            }

            _dbContext.SubElements.Remove(subElement);

            _dbContext.SaveChanges();
        }
    }
}
