using System.Collections.Generic;

#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public class FuelType : Entity
    {
        public string Type { get; set; }

        public virtual List<Engine> Engines { get; set; }
    }
}