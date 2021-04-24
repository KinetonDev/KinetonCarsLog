using System.Collections.Generic;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Models
{
    public class CarRecord
    {
        public Car Car { get; set; }
        public int Count { get; set; }
    }
}