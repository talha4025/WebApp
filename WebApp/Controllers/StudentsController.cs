using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Interfaces;
using WebDemo.ViewModels;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentsMap studentsMap;
        public StudentsController(IStudentsMap _studentsMap)
        {
            studentsMap = _studentsMap;
        }

        [HttpGet]
        public IEnumerable<StudentsViewModel> Get()
        {
            return studentsMap.GetAll();
        }

        [HttpGet("{id}")]
        public StudentsViewModel Search(int id)
        {
            return studentsMap.Search(id);
        }

        // POST api/user
        [HttpPost]
        public StudentsViewModel Post([FromBody] StudentsViewModel student)
        {
            return studentsMap.Create(student);
        }
        // PUT api/user/5
        [HttpPut("{id}")]
        public bool Put([FromBody] StudentsViewModel student)
        {
            return studentsMap.Update(student);
        }
        // DELETE api/user/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return studentsMap.Delete(id);
        }
    }
}
