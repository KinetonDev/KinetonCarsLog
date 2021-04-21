using System;
using System.Threading.Tasks;

namespace KinetonCarsLog.Application.Contracts
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        ICarRepository Cars { get; }
        Task<int> SaveChangesAsync();
    }
}