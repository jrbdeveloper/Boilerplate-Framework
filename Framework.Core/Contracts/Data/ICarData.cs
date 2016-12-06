using Framework.Core.Enums;
using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Core.Contracts.Data
{
    public interface ICarData
    {
        CarViewModel Create(string seats, string steeringWheel, CarEngines engine);

        IEnumerable<CarViewModel> GetAll();
    }
}