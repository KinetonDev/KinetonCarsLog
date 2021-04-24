using System.Threading;
using System.Threading.Tasks;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Persistence.DatabaseContext;
using KinetonCarsLog.Persistence.Repositories;

namespace KinetonCarsLog.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private ICarRepository _cars;
        private IReportRepository _reports;
        private ICarColorRepository _carColors;
        private IManufacturerRepository _manufacturers;
        private ICarTypeRepository _carTypes;
        private IFuelTypeRepository _fuelTypes;
        
        public UnitOfWork(AppDbContext context)
        {
            _appDbContext = context;
        }

        public ICarRepository Cars => _cars ??= new CarRepository(_appDbContext);
        
        public IReportRepository Reports => _reports ??= new ReportRepository(_appDbContext);
        
        public ICarColorRepository CarColors => _carColors ??= new CarColorRepository(_appDbContext);
        
        public IManufacturerRepository Manufacturers => _manufacturers ??= new ManufacturerRepository(_appDbContext);
        
        public ICarTypeRepository CarTypes => _carTypes ??= new CarTypeRepository(_appDbContext);
        
        public IFuelTypeRepository FuelTypes => _fuelTypes ??= new FuelTypeRepository(_appDbContext);

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync(CancellationToken.None);
        }
        
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _appDbContext.DisposeAsync();
        }
    }
}