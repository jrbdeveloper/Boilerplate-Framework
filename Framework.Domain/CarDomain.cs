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

        public CarViewModel GetById(int id)
        {
            return _carData.GetById(id);
        }

        public IEnumerable<CarViewModel> GetFiltered()
        {
            return GetAll().FilterByColor("Fabric").FilterByMake("No Controls");
        }
    }
}