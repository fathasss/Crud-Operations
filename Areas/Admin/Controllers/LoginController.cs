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
            int result = UserLoginAccess.UserControl(kname, kpass);
            if (result == 1 && kname == "fatihas")
            {
                user.UserRole = LoginType.Admin.ToString();
                if (user.UserRole == LoginType.Admin.ToString())
                {
                    Session.Add("Login", kname);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session.Abandon();
                    ViewBag.Message = "Admin Kullanıcısı ile giriş yapmadınız.";
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                Session.Abandon();
                ViewBag.Message = "Yanlış kullanıcı adı ve şifre.";
                return RedirectToAction("Index","Login");
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