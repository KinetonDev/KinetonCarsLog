using System.Collections.Generic;

#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public class CarColor : Entity
    {
        public string ColorName { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}
