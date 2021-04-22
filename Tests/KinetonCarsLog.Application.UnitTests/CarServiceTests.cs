using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Application.Interfaces;
using KinetonCarsLog.Application.Services;
using KinetonCarsLog.Domain.Entities;
using Moq;
using Xunit;

namespace KinetonCarsLog.Application.UnitTests
{
    public class CarServiceTests
    {
        private ICarService _sut;

        [Fact]
        public async Task GetAllCars_WhenCalled_ShouldReturnListOfCars()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var fakeListOfCars = GetTestCarsData();
            mockUnitOfWork.Setup(uow => uow.Cars.GetAllAsync()).Returns(Task.FromResult(fakeListOfCars));
            _sut = new CarService(mockUnitOfWork.Object);

            var cars = await _sut.GetAllCarsAsync();
            
            Assert.Equal(fakeListOfCars, cars);
        }

        private static IEnumerable<Car> GetTestCarsData()
        {
            return new List<Car>()
            {
                new() {Id = 1, Color = new CarColor{ColorName = "Red"},
                    CarType = new CarType{Type = "Sedan"}, SeatCount = 4, 
                    Manufacturer = new Manufacturer{Country = "Japan", Name = "Mazda"}, 
                    Model = "Model", Engine = new Engine()},
                new() {Id = 1, Color = new CarColor{ColorName = "Red"},
                    CarType = new CarType{Type = "Sedan"}, SeatCount = 4, 
                    Manufacturer = new Manufacturer{Country = "Japan", Name = "Mazda"}, 
                    Model = "Model", Engine = new Engine()},
                new() {Id = 1, Color = new CarColor{ColorName = "Red"},
                    CarType = new CarType{Type = "Sedan"}, SeatCount = 4, 
                    Manufacturer = new Manufacturer{Country = "Japan", Name = "Mazda"}, 
                    Model = "Model", Engine = new Engine()},
            };
        } 
    }
}