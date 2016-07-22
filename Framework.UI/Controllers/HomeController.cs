using System.Web.Mvc;

namespace Framework.UI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var fabricSeatsWithNoSteeringWheelControls = GetAllCars().FilterBySeat("Fabric").FilterBySteeringWheel("No Controls").Count;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}