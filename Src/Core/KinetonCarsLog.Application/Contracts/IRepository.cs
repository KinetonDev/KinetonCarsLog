using System.Collections.Generic;
using KinetonCarsLog.Domain.Entities;

namespace KinetonCarsLog.Application.Contracts
{
    public interface IRepository<T>
    {
        T GetByIdOrDefault();
        
        List<T> GetAll();
        
        T Create(T car);
        
        void UpdateById(T car);
        
        void DeleteById();
        
        void SaveChanges();
    }
}
