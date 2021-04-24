#nullable disable

namespace KinetonCarsLog.Domain.Entities
{
    public class ReportsCars
    {
        public int ReportId { get; set; }
        
        public int CarId { get; set; }
        
        public int CountOfCars { get; set; }

        public virtual Car Car { get; set; }
        
        public virtual Report Report { get; set; }
    }
}
