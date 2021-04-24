using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Contracts
{
    public interface ICarRepository : IAsyncRepository<Car>
    {
        Task<Car> GetCertainCarOrDefaultAsync(Car car);
    }
}