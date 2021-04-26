using System;
using KinetonCarsLog.Application.Interfaces;

namespace KinetonCarsLog.Application.Services
{
    public class DateTImeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
        
        public DateTime UtcNow => DateTime.UtcNow;
        
        public DateTime Today => DateTime.Today;
        
        public DateTime UtcToday => DateTime.Now.Date;
    }
}