using CrudOperatorEntity;
using StudentDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CrudOperatorUI.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string kname,string kpass)
        {
            int result = UserLoginAccess.UserControl(kname, kpass);
            if (result == 1)
            {
                Session.Add("Login", kname);
                return RedirectToAction("Index", "Student");
            }
            else
            {
                Session["Login"] = 0;
                ViewBag.Message = "Yanlış kullanıcı adı ve şifre";
                return View();  
            }
        }
        public ActionResult Logout()
        {
            Session["Login"] = 0;
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}