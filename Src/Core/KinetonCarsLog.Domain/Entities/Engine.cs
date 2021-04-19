using System.Collections.Generic;

#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public class Engine
    {
        public int Id { get; set; }
        
        public int FuelTypeId { get; set; }
        
        public string Name { get; set; }
        
        public int Rpm { get; set; }
        
        public int FuelConsumption { get; set; }
        
        public int Capacity { get; set; }
        
        public virtual FuelType FuelType { get; set; }
        
        public virtual List<Car> Cars { get; set; }
    }
}
