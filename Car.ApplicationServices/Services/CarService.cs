using System.Collections.Generic;
using CarEntity = Car.Core.Entities.Car;
using Car.Core.Interfaces;

namespace Car.ApplicationServices.Services
{
    public class CarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CarEntity> GetAllCars()
        {
            return _repository.GetAll();
        }

        public CarEntity? GetCar(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateCar(CarEntity car)
        {
            _repository.Add(car);
        }

        public void UpdateCar(CarEntity car)
        {
            _repository.Update(car);
        }

        public void DeleteCar(int id)
        {
            _repository.Delete(id);
        }
    }
}
