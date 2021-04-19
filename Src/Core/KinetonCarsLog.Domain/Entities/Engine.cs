using KinetonCarsLog.Domain.Enums;

namespace KinetonCarsLog.Domain.Entities
{
    public class Engine
    {
        public int Id { get; set; }
        
        public FuelType FuelType { get; set; }

        public string Name { get; set; }

        public int Rpm { get; set; }

        public int FuelConsumption { get; set; }

        public int Capacity { get; set; }
    }
}   