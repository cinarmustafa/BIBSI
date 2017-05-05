using BIBSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Context db = new Context();
            return View(db.Basvurular.ToList());
        }

        public ActionResult TumIlanlar()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        }
    }
}