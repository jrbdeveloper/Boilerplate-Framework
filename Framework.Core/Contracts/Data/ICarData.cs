using Framework.Core.Enums;
using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Core.Contracts.Data
{
    public interface ICarData
    {
        CarViewModel Create(int id, string make, string model, int year, string color, CarEngines engine);

        IEnumerable<CarViewModel> GetAll();

        CarViewModel GetById(int id);
    }
}