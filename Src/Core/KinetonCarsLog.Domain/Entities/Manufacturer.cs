using System.Collections.Generic;

#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public  class Manufacturer : Entity
    {
        public string Name { get; set; }
        
        public string Country { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}
