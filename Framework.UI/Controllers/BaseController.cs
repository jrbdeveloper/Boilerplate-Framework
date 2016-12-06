using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Framework.UI.Controllers
{
    public class BaseController : Controller
    {
        //protected User CurrentUser { get; set; }

        //protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected ActionResult Error()
        {
            return View();
        }

        protected void GetBuildVersion()
        {
            Assembly web = Assembly.GetExecutingAssembly();
            AssemblyName webName = web.GetName();

            ViewBag.BuildVersion = string.Format("Build Version: {0}", webName.Version.ToString());
        }

        protected IEnumerable<SelectListItem> GetList<T>(IEnumerable<T> collection)
        {
            var list = from item in collection
                       select new SelectListItem
                       {
                           //Text = item.text,
                           //Value = item.value
                       };

            var selectListItems = list as SelectListItem[] ?? list.ToArray();

            return selectListItems;
        }
    }
}