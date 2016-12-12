using Framework.Core.Contracts.Domain;
using Framework.Core.ViewModels;
using System.Web.Mvc;

namespace Framework.UI.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonDomain _personDomain;

        public PeopleController(IPersonDomain personDomain)
        {
            _personDomain = personDomain;
        }

        public ActionResult Index()
        {
            var model = new PersonViewModel
            {
                //People = _personDomain.GetByHeightAndFirst(new Measurement
                //{
                //    Feet = 5,
                //    Inches = 6
                //}, "Jim"),

                //PeopleCount = _personDomain.GetHeadCount()
            };

            return View(model);
        }
    }
}