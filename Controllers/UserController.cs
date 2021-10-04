using CrudOperatorEntity;
using CrudOperatorUI.Attribute;
using StudentDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperatorUI.Controllers
{
    public class UserController : Controller
    {
        UserEditAccessLayer login = null;
        public UserController()
        {
            login = new UserEditAccessLayer();
        }
        // GET: User
        [FilterLog]
        public ActionResult UserIndex()
        {
            IEnumerable<UserLogin> users = login.GetAllUser();
            return View(users);
        }

        // GET: User/Details/5
        [FilterLog]
        public ActionResult UserDetails(int id)
        {
            UserLogin log = login.GetUserData(id);
            return View(log);
        }

        // GET: User/Create
        public ActionResult UserCreate()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [FilterLog]
        public ActionResult UserCreate(UserLogin user)
        {
            try
            {
                // TODO: Add insert logic here
                login.AddUser(user);
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        
        public ActionResult UserEdit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [FilterLog]
        public ActionResult UserEdit(UserLogin user)
        {
            try
            {
                // TODO: Add update logic here
                login.UpdateUser(user);
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult UserDelete(int id)
        {
            UserLogin log = login.GetUserData(id);
            return View(log);
        }

        // POST: User/Delete/5
        [HttpPost]
        [FilterLog]
        public ActionResult UserDelete(UserLogin user)
        {
            try
            {
                // TODO: Add delete logic here
                login.DeleteUser(user.UserId);
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
