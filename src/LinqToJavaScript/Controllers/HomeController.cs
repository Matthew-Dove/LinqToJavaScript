using System.Web.Mvc;

namespace LinqToJavaScript.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
    }
}
