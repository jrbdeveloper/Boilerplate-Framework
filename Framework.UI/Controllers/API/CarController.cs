using Framework.Core.Contracts.Domain;
using Framework.Core.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace Framework.UI.Controllers.API
{
    public class CarController : BaseApiController
    {
        private readonly ICarDomain _carDomain;

        public CarController(ICarDomain carDomain)
        {
            _carDomain = carDomain;
        }
        
        public IEnumerable<ListItemModel> Get()
        {
            return _carDomain.GetCars();
        }

        public IEnumerable<CarViewModel> GetCars()
        {
            return _carDomain.GetAll();
        }

        // POST: api/Car
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Car/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Car/5
        public void Delete(int id)
        {
        }
    }
}