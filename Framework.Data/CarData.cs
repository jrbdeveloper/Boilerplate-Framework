using Framework.Core.Contracts.Data;
using Framework.Core.Enums;
using Framework.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data
{
    public class CarData : BaseData, ICarData
    {
        public CarViewModel Create(int id, string seats, string steeringWheel, CarEngines engine)
        {
            var car = new CarViewModel
            {
                ID = id,
                Seat = seats,
                SteeringWheel = steeringWheel,
                Engine = engine
            };

            return car;
        }

        public  IEnumerable<CarViewModel> GetAll()
        {
            var cars = new List<CarViewModel>();

            cars.Add(Create(1, "Leather", "Full Controls", CarEngines.EightCylinder));
            cars.Add(Create(2, "Leather", "No Controls", CarEngines.EightCylinder));
            cars.Add(Create(3, "Fabric", "Some Controls", CarEngines.SixCylinder));
            cars.Add(Create(4, "Fabric", "No Controls", CarEngines.FourCylinder));
            cars.Add(Create(5, "Fabric", "No Controls", CarEngines.SixCylinder));

            return cars;
        }

        public CarViewModel GetById(int id)
        {
            return GetAll().SingleOrDefault(i => i.ID.Equals(id));
        }
    }
}