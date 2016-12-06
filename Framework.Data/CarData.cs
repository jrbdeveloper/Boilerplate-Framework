using Framework.Core.Contracts.Data;
using Framework.Core.Enums;
using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Data
{
    public class CarData : BaseData, ICarData
    {
        public CarViewModel Create(string seats, string steeringWheel, CarEngines engine)
        {
            var car = new CarViewModel {
                Seat = seats,
                SteeringWheel = steeringWheel,
                Engine = engine
            };

            return car;
        }

        public  IEnumerable<CarViewModel> GetAll()
        {
            var cars = new List<CarViewModel>();

            cars.Add(Create("Leather", "Full Controls", CarEngines.EightCylinder));
            cars.Add(Create("Leather", "No Controls", CarEngines.EightCylinder));
            cars.Add(Create("Fabric", "Some Controls", CarEngines.SixCylinder));
            cars.Add(Create("Fabric", "No Controls", CarEngines.FourCylinder));
            cars.Add(Create("Fabric", "No Controls", CarEngines.SixCylinder));

            return cars;
        }
    }
}