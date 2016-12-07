using Framework.Core.Contracts.Data;
using Framework.Core.Contracts.Domain;
using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Domain
{
    public class CarDomain : BaseModel, ICarDomain
    {
        private readonly ICarData _carData;

        public CarDomain(ICarData carData)
        {
            _carData = carData;
        }

        public IEnumerable<CarViewModel> GetAll()
        {
            return _carData.GetAll();
        }

        public IEnumerable<CarViewModel> GetFiltered()
        {
            return GetAll().FilterBySeat("Fabric").FilterBySteeringWheel("No Controls");
        }
    }
}