using System.Collections.Generic;

#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public class FuelType
    {
        public int Id { get; set; }
        
        public string Type { get; set; }

        public virtual List<Engine> Engines { get; set; }
    }
}
