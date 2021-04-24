using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinetonCarsLog.Application.Models;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();

        Task<bool> ReportCarsAsync(List<CarRecord> car);
    }
}