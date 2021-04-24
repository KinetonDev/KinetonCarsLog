using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Domain.Entities;
using KinetonCarsLog.Persistence.DatabaseContext;
using KinetonCarsLog.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace KinetonCarsLog.Persistence.Repositories
{
    public class ReportRepository : AsyncRepository<Report>, IReportRepository
    {
        public ReportRepository(DbContext dbContext) : base(dbContext) { }
        
        private AppDbContext AppDbContext => DbContext as AppDbContext;
    }
}