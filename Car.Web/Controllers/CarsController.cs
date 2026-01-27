using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Car.ApplicationServices.Services;
using CarEntity = Car.Core.Entities.Car;
using System;
using System.IO;

namespace Car.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarService _carService;

        public CarsController(CarService carService)
        {
            _carService = carService;
        }

        // READ: list
        public IActionResult Index()
        {
            var cars = _carService.GetAllCars();
            return View(cars);
        }

        // READ: details
        public IActionResult Details(int id)
        {
            var car = _carService.GetCar(id);
            if (car == null) return NotFound();

            return View(car);
        }

        // CREATE: form
        public IActionResult Create()
        {
            return View();
        }

        // CREATE: submit (with image upload)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarEntity car, IFormFile? imageFile)
        {
            if (!ModelState.IsValid) return View(car);

            if (imageFile != null && imageFile.Length > 0)
            {
                SaveImage(car, imageFile);
            }

            _carService.CreateCar(car);
            return RedirectToAction(nameof(Index));
        }

        // EDIT: form
        public IActionResult Edit(int id)
        {
            var car = _carService.GetCar(id);
            if (car == null) return NotFound();

            return View(car);
        }

        // EDIT: submit (optional image update)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarEntity car, IFormFile? imageFile)
        {
            if (!ModelState.IsValid) return View(car);

            if (imageFile != null && imageFile.Length > 0)
            {
                SaveImage(car, imageFile);
            }

            _carService.UpdateCar(car);
            return RedirectToAction(nameof(Index));
        }

        // DELETE: confirm page
        public IActionResult Delete(int id)
        {
            var car = _carService.GetCar(id);
            if (car == null) return NotFound();

            return View(car);
        }

        // DELETE: submit
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _carService.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }

        private static void SaveImage(CarEntity car, IFormFile imageFile)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            car.ImageUrl = "/images/" + fileName;
        }
    }
}
