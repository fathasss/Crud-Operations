using CrudOperatorEntity;
using CrudOperatorUI.Attribute;
using StudentDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CrudOperatorUI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [FilterLog]
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }
        [FilterLog]
        [HttpPost]
        public ActionResult Index(string kname, string kpass)
        {
            UserLogin user = new UserLogin();
            int result = UserLoginAccess.AdminUserControl(kname, kpass);
            if (result == 1)
            {
                Session.Add("AdminLogin", kname);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session.Abandon();
                ViewBag.Message = "Admin Kullanıcısı ile giriş yapmadınız.";
                return View("Index", "Login");
            }                                     
        }
        [FilterLog]
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index" , "Login");
        }
    }
}