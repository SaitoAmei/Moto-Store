
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.SqlClient;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            SqlConnection connection = DbCreating.Connection();
            DbCreating.Creating_Db(connection);
            DbCreating.Insert_Defolts(connection);
            Query query = new Query();
            var data = query.Get_Data(connection);
            ViewBag.Motos = data;
            DbCreating.Creating_PurchaseDb(connection);
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

        [HttpGet]
        public ActionResult Buy()
        {
            
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            return "Спасибо," + ", за покупку!";
        }
    }
}