using CrudOperatorUI.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperatorUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [FilterLog]
        public ActionResult About()
        {
            return View();
        }
        [FilterLog]
        public ActionResult Contact()
        {
            return View();
        }
    }
}