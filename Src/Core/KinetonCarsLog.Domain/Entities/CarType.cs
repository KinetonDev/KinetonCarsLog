using System.Collections.Generic;

#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public class CarType : Entity<int>
    {
        public string Type { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}
