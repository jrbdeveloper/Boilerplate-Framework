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
            return View();
        }

        public ActionResult Create()
        {
            return View("Details");
        }

        public ActionResult Details(int id)
        {
            return View(_personDomain.GetById(id));
        }

        public ActionResult Save(PersonViewModel model)
        {
            _personDomain.Save(model);

            return RedirectToAction("Index");
        }
    }
}