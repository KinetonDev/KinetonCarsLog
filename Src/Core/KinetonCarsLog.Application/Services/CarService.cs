using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Application.Interfaces;
using KinetonCarsLog.Application.Models;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Services
{
    public class CarService : ICarService, IDisposable, IAsyncDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _unitOfWork.Cars.GetAllAsync();
        }

        public async Task<bool> ReportCarsAsync(List<CarRecord> carRecords)
        {
            if (carRecords == null)
            {
                throw new ArgumentNullException(nameof(carRecords), "Parameter can't be null");
            }

            if (carRecords.Count == 0)
            {
                return false;
            }

            var newReport = new Report
            {
                CreatedUtc = DateTime.UtcNow, 
                ReportsCars = new List<ReportsCars>()
            };
            
            foreach (var carRecord in carRecords)
            {
                var car = await _unitOfWork.Cars.GetCertainCarOrDefaultAsync(carRecord.Car);

                if (car == null)
                {
                    var carColor = 
                        await _unitOfWork.CarColors.GetCarColorOrDefaultAsync(carRecord.Car.Color);
                    var fuelType =
                        await _unitOfWork.FuelTypes.GetFuelTypeOrDefaultAsync(carRecord.Car.Engine.FuelType);
                    var manufacturer =
                        await _unitOfWork.Manufacturers.GetManufacturerOrDefaultAsync(carRecord.Car.Manufacturer);
                    var carType =
                        await _unitOfWork.CarTypes.GetCarTypeOrDefaultAsync(carRecord.Car.CarType);

                    carRecord.Car.Color = carColor ?? carRecord.Car.Color;
                    carRecord.Car.Engine.FuelType = fuelType ?? carRecord.Car.Engine.FuelType;
                    carRecord.Car.Manufacturer = manufacturer ?? carRecord.Car.Manufacturer;
                    carRecord.Car.CarType = carType ?? carRecord.Car.CarType;
                }
                
                var reportsCars = new ReportsCars
                {
                    CountOfCars = carRecord.Count,
                    Report = newReport, 
                    Car = car ?? carRecord.Car
                };
                
                newReport.ReportsCars.Add(reportsCars);  
            }

            await _unitOfWork.Reports.AddAsync(newReport);
            await _unitOfWork.SaveChangesAsync();
            
            return true;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _unitOfWork.DisposeAsync();
        }
    }
}