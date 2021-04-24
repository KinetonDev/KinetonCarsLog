using System;
using System.Threading.Tasks;

namespace KinetonCarsLog.Application.Contracts
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        ICarRepository Cars { get; }
        
        IReportRepository Reports { get; }
        
        ICarColorRepository CarColors { get; }
        
        ICarTypeRepository CarTypes { get; }
        
        IFuelTypeRepository FuelTypes { get; }
        
        IManufacturerRepository Manufacturers { get; }
        
        Task<int> SaveChangesAsync();
    }
}