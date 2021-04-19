using System.Collections.Generic;
using KinetonCarsLog.Domain.Enums;

namespace KinetonCarsLog.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public CarType CarType { get; set; }

        public Engine Engine { get; set; }

        public Color Color { get; set; }

        public string Model { get; set; }

        public int SeatCount { get; set; }

        public List<ReportCar> Reports { get; set; }
    }
}