using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Contracts
{
    public interface ICarRepository : IAsyncRepository<Car>
    {
        
    }
}