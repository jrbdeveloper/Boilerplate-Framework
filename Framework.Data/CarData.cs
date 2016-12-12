using Framework.Core.Contracts.Data;
using Framework.Core.Enums;
using Framework.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data
{
    public class CarData : BaseData, ICarData
    {
        public CarViewModel Create(int id, string make, string model, int year, string color, CarEngines engine)
        {
            var car = new CarViewModel
            {
                ID = id,
                Make = make,
                Model = model,
                Year = year,
                Color = color,
                Engine = engine
            };

            return car;
        }

        public  IEnumerable<CarViewModel> GetAll()
        {
            var cars = new List<CarViewModel>();

            cars.Add(Create(1, "Dodge", "Challenger", 2010, "Black", CarEngines.EightCylinder));
            cars.Add(Create(2, "Ford", "Mustange", 2015, "Red", CarEngines.EightCylinder));
            cars.Add(Create(3, "Chevy", "Camero", 2016, "Yellow", CarEngines.SixCylinder));
            cars.Add(Create(4, "Dodge", "Charger", 2017, "Orange", CarEngines.FourCylinder));
            cars.Add(Create(5, "Chrysler", "300", 2005, "White", CarEngines.SixCylinder));

            return cars;
        }

        public CarViewModel GetById(int id)
        {
            return GetAll().SingleOrDefault(i => i.ID.Equals(id));
        }
    }
}