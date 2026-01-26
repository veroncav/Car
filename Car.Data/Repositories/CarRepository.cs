using Car.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CarEntity = Car.Core.Entities.Car;

namespace Car.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarEntity> GetAll()
        {
            return _context.Cars.AsNoTracking().ToList();
        }

        public CarEntity? GetById(int id)
        {
            return _context.Cars.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Add(CarEntity car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Update(CarEntity car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (car == null) return;

            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
    }
}
