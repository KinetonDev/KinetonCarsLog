using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Application.Interfaces;
using KinetonCarsLog.Application.Models;
using KinetonCarsLog.Application.Services;
using KinetonCarsLog.Domain.Entities;
using Moq;
using Xunit;

namespace KinetonCarsLog.Application.UnitTests
{
    public class ReportServiceTests
    {
        private IReportService _sut;

        // [Fact(Skip = "Not working")]
        // public async Task GetAllCars_WhenCalled_ReturnsListOfCars()
        // {
        //     var mockUnitOfWork = new Mock<IUnitOfWork>();
        //     var fakeListOfCars = GetTestCarsData();
        //     mockUnitOfWork.Setup(uow => uow.Cars.GetAllAsync()).ReturnsAsync(fakeListOfCars);
        //
        //     _sut = new ReportService(mockUnitOfWork.Object);
        //
        //     var cars = await _sut.GetAllCarsAsync();
        //     
        //     Assert.Equal(fakeListOfCars, cars);
        // }

        [Fact]
        public async Task ReportCarsAsync_CarExists_ReturnsTrue()
        {
            var existingCar = GetTestCar();
            var carsToAdd = new List<CarRecord>
            {
                new () {Car = existingCar, Count = It.Is<int>(c => c > 0)}
            };
            var existingReports = new List<Report>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockDateTimeService = new Mock<IDateTimeService>();
            mockUnitOfWork.Setup(uow => uow.Cars.GetCertainCarOrDefaultAsync(existingCar)).ReturnsAsync(existingCar);
            mockUnitOfWork.Setup(uow => uow.Reports.AddAsync(It.IsAny<Report>()))
                .Callback(() => existingReports.Add(It.IsAny<Report>()));
            _sut = new ReportService(mockUnitOfWork.Object, mockDateTimeService.Object);

            var result = await _sut.ReportCarsAsync(carsToAdd);
            
            Assert.True(result);
            Assert.True(existingReports.Any());
        }
        
        [Fact]
        public async Task ReportCarsAsync_CarNotExists_ReturnsTrue()
        {
            var carsToAdd = new List<CarRecord>
            {
                new ()
                {
                    Car = GetTestCar(), 
                    Count = It.Is<int>(c => c > 0)
                }
            };
            var existingReports = new List<Report>();
            var mockDateTimeService = new Mock<IDateTimeService>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Cars.GetCertainCarOrDefaultAsync(It.IsAny<Car>()))
                .ReturnsAsync((Car) null);
            mockUnitOfWork.Setup(uow => uow.Reports.AddAsync(It.IsAny<Report>()))
                .Callback(() => existingReports.Add(It.IsAny<Report>()));
            mockUnitOfWork.Setup(uow => uow.CarColors.GetCarColorOrDefaultAsync(It.IsAny<CarColor>()))
                .ReturnsAsync(It.IsAny<CarColor>());
            mockUnitOfWork.Setup(uow => uow.FuelTypes.GetFuelTypeOrDefaultAsync(It.IsAny<FuelType>()))
                .ReturnsAsync(It.IsAny<FuelType>());
            mockUnitOfWork.Setup(uow => uow.CarTypes.GetCarTypeOrDefaultAsync(It.IsAny<CarType>()))
                .ReturnsAsync(It.IsAny<CarType>());
            mockUnitOfWork.Setup(uow => uow.Manufacturers.GetManufacturerOrDefaultAsync(It.IsAny<Manufacturer>()))
                .ReturnsAsync(It.IsAny<Manufacturer>());
            _sut = new ReportService(mockUnitOfWork.Object, mockDateTimeService.Object);

            var result = await _sut.ReportCarsAsync(carsToAdd);
            
            Assert.True(result);
            Assert.True(existingReports.Any());
        }

        [Fact]
        public async Task ReportCarsAsync_PassNull_ThrowsArgumentNullException()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockDateTimeService = new Mock<IDateTimeService>();
            _sut = new ReportService(mockUnitOfWork.Object, mockDateTimeService.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _sut.ReportCarsAsync(null));
        }
        
        [Fact]
        public async Task ReportCarsAsync_PassEmptyList_ReturnsFalse()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockDateTimeService = new Mock<IDateTimeService>();
            _sut = new ReportService(mockUnitOfWork.Object, mockDateTimeService.Object);
            
            var result = await _sut.ReportCarsAsync(new List<CarRecord>());
            
            Assert.False(result);
        }
        
        public static List<Car> GetTestCarsData()
        {
            return new()
            {
                GetTestCar(),
                GetTestCar(),
                GetTestCar(),
            };
        }

        public static Car GetTestCar() => new() {
            Id = 1,
            SeatCount = 4,
            Color = new CarColor
            {
                ColorName = "Red"
            },
            CarType = new CarType
            {
                Type = "Sedan"
            },
            Manufacturer = new Manufacturer
            {
                Country = "Japan",
                Name = "Mazda"
            },
            Engine = new Engine
            {
                Capacity = 20,
                Name = "Engine",
                Rpm = 40,
                FuelConsumption = 40,
                FuelType = new FuelType
                {
                    Type = "petrol 98"
                }
            },
        };
    }
}