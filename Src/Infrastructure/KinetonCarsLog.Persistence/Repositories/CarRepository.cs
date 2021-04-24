using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Domain.Entities;
using KinetonCarsLog.Persistence.DatabaseContext;
using KinetonCarsLog.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace KinetonCarsLog.Persistence.Repositories
{
    public class CarRepository : AsyncRepository<Car>, ICarRepository
    {
        public CarRepository(DbContext dbContext) : base(dbContext) { }
        
        private AppDbContext AppDbContext => DbContext as AppDbContext;
        
        public async Task<Car> GetCertainCarOrDefaultAsync(Car car)
        {
            return await AppDbContext.Cars.FirstOrDefaultAsync((c) =>
                c.Model == car.Model &&
                   c.Manufacturer.Name == car.Manufacturer.Name &&
                   c.Engine.Name == car.Engine.Name &&
                   c.Color.ColorName == car.Color.ColorName
            );
        }
    }
}