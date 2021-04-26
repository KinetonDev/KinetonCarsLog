using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinetonCarsLog.Application.Models;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetCarsByLastDaysAsync(int countOfDays);

        Task<bool> ReportCarsAsync(List<CarRecord> car);
    }
}