using Framework.Core.Contracts.Domain;
using Framework.Core.ViewModels;
using System.Web.Mvc;

namespace Framework.UI.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarDomain _carDomain;

        public CarController(ICarDomain carDomain)
        {
            _carDomain = carDomain;
        }

        public ActionResult Index()
        {
            var model = new CarViewModel
            {
                Cars = _carDomain.GetFiltered()
            };

            return View(model);
        }
    }
}