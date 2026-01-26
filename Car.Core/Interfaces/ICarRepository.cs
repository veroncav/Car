using System.Collections.Generic;
using CarEntity = Car.Core.Entities.Car;

namespace Car.Core.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<CarEntity> GetAll();
        CarEntity? GetById(int id);
        void Add(CarEntity car);
        void Update(CarEntity car);
        void Delete(int id);
    }
}
