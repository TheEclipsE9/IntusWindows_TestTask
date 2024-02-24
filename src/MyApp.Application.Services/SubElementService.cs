using MyApp.Domain.Contracts.Application;
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

        public SubElement Get(int id)
        {
            var subElement = _dbContext.SubElements.SingleOrDefault(x => x.Id == id);
            if (subElement is null)
            {
                throw new ArgumentException();
            }

            return subElement;
        }

        public void Create(SubElement subElement)
        {
            _dbContext.SubElements.Add(subElement);

            _dbContext.SaveChanges();
        }

        public void Update(int id, SubElement subElement)
        {
            var dbSubElement = _dbContext.SubElements.SingleOrDefault(x => x.Id == id);
            if (dbSubElement is null)
            {
                throw new ArgumentException();
            }

            dbSubElement.Type = subElement.Type;
            dbSubElement.Width = subElement.Width;
            dbSubElement.Height = subElement.Height;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var subElement = _dbContext.SubElements.SingleOrDefault(x => x.Id == id);
            if (subElement is null)
            {
                throw new ArgumentException();
            }

            _dbContext.SubElements.Remove(subElement);

            _dbContext.SaveChanges();
        }
    }
}
