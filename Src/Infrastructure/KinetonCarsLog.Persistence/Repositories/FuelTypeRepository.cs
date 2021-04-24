using System.Threading.Tasks;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Domain.Entities;
using KinetonCarsLog.Persistence.DatabaseContext;
using KinetonCarsLog.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace KinetonCarsLog.Persistence.Repositories
{
    public class FuelTypeRepository : AsyncRepository<FuelType>, IFuelTypeRepository
    {
        public FuelTypeRepository(DbContext dbContext) : base(dbContext) { }
        
        private AppDbContext AppDbContext => DbContext as AppDbContext;
        
        public async Task<FuelType> GetFuelTypeOrDefaultAsync(FuelType fuelType)
        {
            return await AppDbContext.FuelTypes.FirstOrDefaultAsync(f => f.Type == fuelType.Type);
        }
    }
}