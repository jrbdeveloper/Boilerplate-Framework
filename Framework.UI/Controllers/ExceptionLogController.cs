using Framework.Core.Contracts.Domain;
using System.Web.Mvc;

namespace Framework.UI.Controllers
{
    public class ExceptionLogController : BaseController
    {
        private readonly IExceptionLogDomain _exceptionLogDomain;

        public ExceptionLogController(IExceptionLogDomain exceptionLogDomain)
        {
            _exceptionLogDomain = exceptionLogDomain;
        }

        public ActionResult Index()
        {
            var list = _exceptionLogDomain.GetAll();
            return View(list);
        }

        public JsonResult GetStackTrace(int id)
        {
            var value = _exceptionLogDomain.GetStackTrace(id);

            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}