using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.Home;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(new IndexModel()
            {
                Nome = "SOS FEEVALE",                
            });
        }

        [HttpPost]
        public ActionResult PostTest()
        {
            return Json(new { itens = new object[0] });
        }

        [HttpGet]
        public ActionResult GetTest()
        {
            return PartialView("nome da partial");
        }
    }
}
