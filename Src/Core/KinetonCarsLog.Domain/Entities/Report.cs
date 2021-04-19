using System;
using System.Collections.Generic;

#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        
        public DateTime CreatedUtc { get; set; }

        public virtual List<ReportsCar> ReportsCars { get; set; }
    }
}
