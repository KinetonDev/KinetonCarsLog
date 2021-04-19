using System;
using System.Collections.Generic;

namespace KinetonCarsLog.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public List<ReportCar> DeliveredCars { get; set; }
    }
}   