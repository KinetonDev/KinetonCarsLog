using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Domain.Entities;
using KinetonCarsLog.Persistence.DatabaseContext;
using KinetonCarsLog.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace KinetonCarsLog.Persistence.Repositories
{
    public class ReportRepository : AsyncRepository<Report>, IReportRepository
    {
        public ReportRepository(DbContext dbContext) : base(dbContext) { }
        
        private AppDbContext AppDbContext => DbContext as AppDbContext;
        
        public async Task<IEnumerable<Report>> GetReportsLaterThanDate(DateTime date)
        {
            var reports = AppDbContext.Reports
                .Include(r => r.ReportsCars)
                .ThenInclude(rc => rc.Car)
                .ThenInclude(c => c.Color)
                .Include(r => r.ReportsCars)
                .ThenInclude(rc => rc.Car)
                .ThenInclude(c => c.Engine)
                .ThenInclude(e => e.FuelType)
                .Include(r => r.ReportsCars)
                .ThenInclude(rc => rc.Car)
                .ThenInclude(c => c.CarType)
                .Include(r => r.ReportsCars)
                .ThenInclude(rc => rc.Car)
                .ThenInclude(c => c.Manufacturer);

            var reportsFilteredByDate = reports.Where(r => r.CreatedUtc > date);

            return await reportsFilteredByDate.ToListAsync();
        }
    }
}