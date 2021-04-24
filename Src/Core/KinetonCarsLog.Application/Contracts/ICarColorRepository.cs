using System.Threading.Tasks;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Contracts
{
    public interface ICarColorRepository : IAsyncRepository<CarColor>
    {
        Task<CarColor> GetCarColorOrDefaultAsync(CarColor carColor);
    }
}