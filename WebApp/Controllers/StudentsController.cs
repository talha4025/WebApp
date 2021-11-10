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
    [Route("api")]
    [ApiController]
    public class StudentsController : Controller
    {
        IStudentsMap studentsMap;
        public StudentsController(IStudentsMap _studentsMap)
        {
            studentsMap = _studentsMap;
        }

        [HttpGet("GetAll")]
        public IEnumerable<StudentsViewModel> Get()
        {
            return studentsMap.GetAll();
        }

        [HttpGet("{id}")]
        public StudentsViewModel Search(int id)
        {
            return studentsMap.Search(id);
        }

        [HttpPost("Create")]
        public StudentsViewModel Post([FromBody] StudentsViewModel student)
        {
            StudentsViewModel stud = student;
            return studentsMap.Create(stud);
        }
        
        [HttpPut("Update")]
        public bool Put([FromBody] StudentsViewModel student)
        {
            return studentsMap.Update(student);
        }
        
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return studentsMap.Delete(id);
        }
    }
}
