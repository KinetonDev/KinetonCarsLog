using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Contracts
{
    public interface IReportRepository : IAsyncRepository<Report>
    {
        Task<IEnumerable<Report>> GetReportsLaterThanDate(DateTime date);
    }
}