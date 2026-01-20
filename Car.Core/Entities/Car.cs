using System;

namespace Car.Core.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }  // Марка
        public string Model { get; set; } // Модель
        public int Year { get; set; }     // Год выпуска
        public string Color { get; set; } // Цвет
        public decimal Price { get; set; } // Цена
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Создано
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow; // Изменено
    }
}
