using System.Threading.Tasks;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Domain.Entities;
using KinetonCarsLog.Persistence.DatabaseContext;
using KinetonCarsLog.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace KinetonCarsLog.Persistence.Repositories
{
    public class ManufacturerRepository : AsyncRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(DbContext dbContext) : base(dbContext) { }
        
        private AppDbContext AppDbContext => DbContext as AppDbContext;
        
        public async Task<Manufacturer> GetManufacturerOrDefaultAsync(Manufacturer manufacturer)
        {
            return await AppDbContext.Manufacturers.FirstOrDefaultAsync(m => m.Name == manufacturer.Name);
        }
    }
}