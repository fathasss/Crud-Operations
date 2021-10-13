using CrudOperatorEntity;
using CrudOperatorUI.Attribute;
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
        [FilterLog]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [FilterLog]
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
                Session.Abandon();
                ViewBag.Message = "Yanlış kullanıcı adı ve şifre";
                return View();  
            }
        }
        [FilterLog]
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}