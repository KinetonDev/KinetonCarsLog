using System.Threading.Tasks;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Domain.Entities;
using KinetonCarsLog.Persistence.DatabaseContext;
using KinetonCarsLog.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace KinetonCarsLog.Persistence.Repositories
{
    public class CarColorRepository : AsyncRepository<CarColor>, ICarColorRepository
    {
        public CarColorRepository(DbContext dbContext) : base(dbContext) { }
        
        private AppDbContext AppDbContext => DbContext as AppDbContext;
        
        public async Task<CarColor> GetCarColorOrDefaultAsync(CarColor carColor)
        {
            return await AppDbContext.CarColors.FirstOrDefaultAsync(cc => cc.ColorName == carColor.ColorName);
        }
    }
}