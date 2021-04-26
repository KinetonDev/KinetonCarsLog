using System;

namespace KinetonCarsLog.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime Now { get; }
        
        DateTime UtcNow { get; }

        DateTime Today { get; }

        DateTime UtcToday { get; }
    }
}