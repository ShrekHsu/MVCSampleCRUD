using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSampleCRUD.Models;

namespace MVCSampleCRUD.Controllers
{
    public class HomeController : Controller
    {
        //呼叫 DB
        Database1Entities DB01 = new Database1Entities();

        public ActionResult Index()
        {
            var DB = DB01.Datebase1.OrderByDescending(m => m.fDate).ToList();

            return View(DB);
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