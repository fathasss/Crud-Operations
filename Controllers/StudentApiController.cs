using CrudOperatorEntity;
using CrudOperatorUI.Utility;
using StudentDataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//Web API
namespace CrudOperatorUI.Controllers
{
    public class StudentApiController : ApiController
    {
        StudentDataAccessLayer layerStudent = new StudentDataAccessLayer();
        // GET: api/StudentApi
        public IEnumerable<Student> Get()
        {
            //All get data
            return layerStudent.GetAllStudent();
        }

        // GET: api/StudentApi/5
        public IHttpActionResult Get(int id)
        {
            //Id get data
            Student arananOgrenci = ApiAccess.getById(id);
            if (arananOgrenci == null)
                return NotFound();
            else
                return Ok(arananOgrenci);
        }

        // POST: api/StudentApi
        [HttpPost]
        public void Post(Student newStudent)
        {
            //Insert Api Method
            ApiAccess.AddStudent(newStudent);
        }

        // PUT: api/StudentApi/5
        public void Put([FromBody] Student newStudent)
        {
            //Update Api Method
            //...
        }

        // DELETE: api/StudentApi/5
        public void Delete(int id)
        {
            //Delete Api method
            ApiAccess.Deleted(id);
        }
    }
}
