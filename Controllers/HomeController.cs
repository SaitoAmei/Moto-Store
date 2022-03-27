
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
            var data =  Query.Get_Data(connection);
            ViewBag.Motos = data;
            DbCreating.Creating_PurchaseDb(connection);
            return View();
        }


        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            ViewBag.Motos = Query.DataSearch(collection["Query"]);
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
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
                Adress = collection["Address"],
                Date = System.DateTime.Now,
                MotoId = id
            
            };

            DbCreating.AddPurcahse(purchase, DbCreating.Connection());

            return "Спасибо," +purchase.Person + purchase.Date + purchase.MotoId+ ", за покупку!";
        }
    }
}