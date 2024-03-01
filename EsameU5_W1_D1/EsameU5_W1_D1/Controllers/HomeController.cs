using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsameU5_W1_D1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Anagrafica()
        {

            return View();
        }

        public ActionResult Verbale()
        {

            return View();
        }

        public ActionResult AnagraficaUtente()
        {

            return View();
        }

        public ActionResult ListaVerbali()
        {

            return View();
        }
    }
}