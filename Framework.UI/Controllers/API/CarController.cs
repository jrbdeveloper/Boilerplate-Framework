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
        
        public IEnumerable<CarViewModel> Get()
        {
            return _carDomain.GetAll();
        }

        public CarViewModel Get(int id)
        {
            return _carDomain.GetById(id);
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
