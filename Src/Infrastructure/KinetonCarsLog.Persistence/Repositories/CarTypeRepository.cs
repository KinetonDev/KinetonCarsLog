using System.Threading.Tasks;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Domain.Entities;
using KinetonCarsLog.Persistence.DatabaseContext;
using KinetonCarsLog.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace KinetonCarsLog.Persistence.Repositories
{
    public class CarTypeRepository : AsyncRepository<CarType>, ICarTypeRepository
    {
        public CarTypeRepository(DbContext dbContext) : base(dbContext) { }
        
        private AppDbContext AppDbContext => DbContext as AppDbContext;
        
        public async Task<CarType> GetCarTypeOrDefaultAsync(CarType carType)
        {
            return await AppDbContext.CarTypes.FirstOrDefaultAsync(ct => ct.Type == carType.Type);
        }
    }
}