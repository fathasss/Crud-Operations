using CrudOperatorEntity;
using StudentDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudOperatorUI.Controllers
{
    public class StudentApiController : ApiController
    {
        StudentDataAccessLayer layerStudent = new StudentDataAccessLayer();
        // GET: api/StudentApi
        public IEnumerable<Student> Get()
        {
            return layerStudent.GetAllStudent().ToList();
        }

        // GET: api/StudentApi/5
        public IHttpActionResult Get(int id)
        {
            var arananOgrenci = (layerStudent.GetAllStudent().ToList().Where(u => u.Id == id)).FirstOrDefault();
            if (arananOgrenci == null)
                return NotFound();
            else
                return Ok(arananOgrenci);
        }

        // POST: api/StudentApi
        public IHttpActionResult Post([FromBody]Student newStudent)
        {
            var ogrenciAdi = newStudent != null ? newStudent.FirstName : "";
            var ogrenciSoyadi = newStudent != null ? newStudent.LastName : "";
            var ogrenciMail = newStudent != null ? newStudent.Email : "";
            var ogrenciPhone = newStudent != null ? newStudent.Mobile : "";
            var ogrenciAddress = newStudent != null ? newStudent.Address : "";
            layerStudent.GetAllStudent().ToList().Add(newStudent);
            return Ok(ogrenciAdi);
        }

        // PUT: api/StudentApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StudentApi/5
        public void Delete(int id)
        {
        }
    }
}
