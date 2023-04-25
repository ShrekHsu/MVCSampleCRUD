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
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(string fTitle,string fImage, DateTime fDate)
        {
            Datebase1 DB1 = new Datebase1();
            DB1.fTitle = fTitle;
            DB1.fImage = fImage;
            DB1.fDate = fDate;
            DB01.Datebase1.Add(DB1);
            DB01.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var Employeeid = DB01.Datebase1.Where(m => m.fId == id).FirstOrDefault();
            DB01.Datebase1.Remove(Employeeid);
            DB01.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var Employeeid = DB01.Datebase1.Where(m => m.fId == id).FirstOrDefault();
            return View(Employeeid);
        }
        [HttpPost]
        public ActionResult Edit(int fid, string fTitle, string fImage, DateTime fDate)
        {
            var Employeeid = DB01.Datebase1.Where(m => m.fId == fid).FirstOrDefault();

            Employeeid.fTitle = fTitle;
            Employeeid.fImage = fImage;
            Employeeid.fDate = fDate;
            DB01.SaveChanges();

            return RedirectToAction("Index");
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