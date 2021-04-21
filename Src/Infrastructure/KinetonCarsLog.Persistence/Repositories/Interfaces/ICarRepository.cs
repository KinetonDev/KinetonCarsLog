using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Persistence.Repositories.Interfaces
{
    public interface ICarRepository : IAsyncRepository<Car>
    {
        
    }
}