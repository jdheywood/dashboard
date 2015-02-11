using System.Web.Mvc;
using Dashboard.SourceControl.Contracts;

namespace Dashboard.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountByUserNameQuery accountByUserNameQuery;

        public HomeController(IAccountByUserNameQuery accountByUserNameQuery)
        {
            this.accountByUserNameQuery = accountByUserNameQuery;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var account = accountByUserNameQuery.Execute("jdheywood");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
