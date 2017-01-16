using Framework.Core.Contracts.Data;
using Framework.Core.Contracts.Domain;
using Framework.Core.ViewModels;
using System.Collections.Generic;

namespace Framework.Domain
{
    public class CarDomain : BaseModel, ICarDomain
    {
        private readonly ICarData _carData;
        private IEnumerable<CarViewModel> _cars;

        public CarDomain(ICarData carData)
        {
            _carData = carData;
        }

        public IEnumerable<CarViewModel> GetAll()
        {
            if (_cars == null)
            {
                _cars = _carData.GetAll();
            }

            return _cars;
        }

        public IEnumerable<ListItemModel> GetCars()
        {
            return _carData.GetCars();
        }

        public CarViewModel GetById(int id)
        {
            return _carData.GetById(id);
        }

        public IEnumerable<CarViewModel> GetFiltered()
        {
            return GetAll().FilterByColor("Red").FilterByMake("Ford");
        }
    }
}