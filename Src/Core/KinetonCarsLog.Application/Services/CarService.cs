using System.Collections.Generic;
using System.Threading.Tasks;
using KinetonCarsLog.Application.Contracts;
using KinetonCarsLog.Application.Interfaces;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Services
{
    public class CarService : ICarService
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
    }
}