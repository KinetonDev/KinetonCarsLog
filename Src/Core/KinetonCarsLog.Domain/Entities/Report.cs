using System;
using System.Collections.Generic;

#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public class Report : Entity
    {
        public DateTime CreatedUtc { get; set; }

        public virtual List<ReportsCars> ReportsCars { get; set; }
    }
}
