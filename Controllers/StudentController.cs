using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CrudOperatorEntity;
using CrudOperatorUI.Attribute;
using Microsoft.Ajax.Utilities;
using StudentDataAccess;

namespace CrudOperatorUI.Controllers
{
    public class StudentController : Controller
    {
        StudentDataAccessLayer studentDataAccessLayer = null;
        public StudentController()
        {
           studentDataAccessLayer = new StudentDataAccessLayer();
        }
        // GET: Student
        [FilterLog]
        public ActionResult Index()
        {
            //List<Currency> currencyList = CurrencyAccessLayer.GetCurrency();
            //ViewData["Doviz"] = currencyList;
            IEnumerable<Student> students = studentDataAccessLayer.GetAllStudent();           
            return View(students);
        }
        [HttpPost]
        [FilterLog]
        public ActionResult Index(string searchString)
        {
            //List<Currency> currencyList = CurrencyAccessLayer.GetCurrency();
            //ViewData["Doviz"] = currencyList;
            IEnumerable<Student> students = studentDataAccessLayer.SearchStudent(searchString);            
            return View(students);
        }
        // GET: Student/Details/5
        [FilterLog]
        public ActionResult Details(int id)
        {
            Student student = studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }

        // GET: Student/Create
        [FilterLog]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [FilterLog]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                studentDataAccessLayer.AddStudent(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        [FilterLog]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        [FilterLog]
        public ActionResult Edit(Student student)
        {
            try
            {
                // TODO: Add update logic here
                studentDataAccessLayer.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FilterLog]
        public ActionResult Delete(Student student)
        {
            try
            {
                // TODO: Add delete logic here
                studentDataAccessLayer.DeleteStudent(student.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
