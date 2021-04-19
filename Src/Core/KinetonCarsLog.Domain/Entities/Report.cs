using System;
using System.Collections.Generic;

#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public class Report : Entity<int>
    {
        public DateTime CreatedUtc { get; set; }

        public virtual List<ReportsCar> ReportsCars { get; set; }
    }
}
