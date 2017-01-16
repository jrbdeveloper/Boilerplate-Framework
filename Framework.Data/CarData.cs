using Framework.Core.Contracts.Data;
using Framework.Core.Enums;
using Framework.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data
{
    public class CarData : BaseData, ICarData
    {
        private IEnumerable<CarViewModel> _allCars;

        public CarViewModel Create(int id, string make, string model, int year, string color, CarEngines engine)
        {
            return new CarViewModel
            {
                ID = id,
                Make = make,
                Model = model,
                Year = year,
                Color = color,
                Engine = engine
            };
        }

        public  IEnumerable<CarViewModel> GetAll()
        {
            if (_allCars == null)
            {
                var cars = new List<CarViewModel>();

                cars.Add(Create(1, "Dodge", "Challenger", 2010, "Black", CarEngines.EightCylinder));
                cars.Add(Create(2, "Ford", "Mustange", 2015, "Red", CarEngines.EightCylinder));
                cars.Add(Create(3, "Chevy", "Camero", 2016, "Yellow", CarEngines.SixCylinder));
                cars.Add(Create(4, "Dodge", "Charger", 2017, "Orange", CarEngines.FourCylinder));
                cars.Add(Create(5, "Chrysler", "300", 2005, "White", CarEngines.SixCylinder));

                _allCars = cars;
            }

            return _allCars;            
        }

        public CarViewModel GetById(int id)
        {
            return GetAll().SingleOrDefault(i => i.ID.Equals(id));
        }

        public IEnumerable<ListItemModel> GetCars()
        {
            return GetAll().Select(i => new ListItemModel {
                Text = i.Model,
                Value = i.ID.ToString()
            });
        }
    }
}