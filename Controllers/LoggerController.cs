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
    public class LoggerController : Controller
    {
        LoggerAccessLayer logger = null;
        public LoggerController()
        {
           logger = new LoggerAccessLayer();
        }
        // GET: Logger
        [FilterLog]
        public ActionResult Logger()
        {
            IEnumerable<Logger> users = logger.GetAllLogger();
            return View(users);
        }

        // GET: Logger/Details/5
        [FilterLog]
        public ActionResult LogDetails(int id)
        {
            Logger log = logger.GetUserData(id);
            return View(log);
        }

        // GET: Logger/Delete/5
        public ActionResult LogDelete(int id)
        {
            Logger user = logger.GetUserData(id);
            return View(user);
        }
        // POST: Logger/Delete/5
        [HttpPost]
        [FilterLog]
        public ActionResult LogDelete(Logger log)
        {
            try
            {
                // TODO: Add delete logic here
                logger.DeleteLogger(log.LoggerId);
                return RedirectToAction("Logger");
            }
            catch
            {
                return View();
            }
        }
    }
}
