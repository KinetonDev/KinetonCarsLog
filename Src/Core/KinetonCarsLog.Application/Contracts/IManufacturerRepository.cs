using System.Threading.Tasks;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Contracts
{
    public interface IManufacturerRepository : IAsyncRepository<Manufacturer>
    {
        Task<Manufacturer> GetManufacturerOrDefaultAsync(Manufacturer manufacturer);
    }
}