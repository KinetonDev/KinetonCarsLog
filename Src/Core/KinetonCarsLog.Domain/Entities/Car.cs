using System.Collections.Generic;

#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        
        public int ManufacturerId { get; set; }
        
        public int CarTypeId { get; set; }
        
        public int EngineId { get; set; }
        
        public int ColorId { get; set; }
        
        public string Model { get; set; }
        
        public int SeatCount { get; set; }

        public virtual CarType CarType { get; set; }
        
        public virtual CarColor Color { get; set; }
        
        public virtual Engine Engine { get; set; }
        
        public virtual Manufacturer Manufacturer { get; set; }
        
        public virtual List<ReportsCar> ReportsCars { get; set; }
    }
}
