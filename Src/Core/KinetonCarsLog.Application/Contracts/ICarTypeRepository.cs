using System.Threading.Tasks;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Contracts
{
    public interface ICarTypeRepository : IAsyncRepository<CarType>
    {
        Task<CarType> GetCarTypeOrDefaultAsync(CarType carType);
    }
}