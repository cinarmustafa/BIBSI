using BIBSI.Models;
using BIBSI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBSI.Controllers
{
    public class HomeController : Controller
    {
        ModelViewer model = new ModelViewer();

        // GET: Home
        public ActionResult Index()
        {
            return View(model);
        }

        public ActionResult Iletisim()
        {
            return View();
        }
    }
}