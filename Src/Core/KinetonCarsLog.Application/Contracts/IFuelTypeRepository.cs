using System.Threading.Tasks;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Contracts
{
    public interface IFuelTypeRepository : IAsyncRepository<FuelType>
    {
        Task<FuelType> GetFuelTypeOrDefaultAsync(FuelType fuelType);
    }
}   