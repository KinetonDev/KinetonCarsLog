using System.Collections.Generic;

#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public class CarColor
    {
        public int Id { get; set; }
        
        public string ColorName { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}
