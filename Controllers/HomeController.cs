
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


        [HttpGet]
        public ActionResult Buy(object id)
        {

            ViewBag.MotoId = id;
            return View();
        }
        [HttpPost]
        public string Buy(FormCollection collection, int id)
        {
            Purchase purchase = new Purchase()
            {
                Person = collection["Person"],
                Adress = collection["Adress"],
                Date = System.DateTime.Now,
                MotoId = id
            
            };
            

            return "Спасибо," +purchase.Person+purchase.Date+purchase.MotoId+ ", за покупку!";
        }
    }
}