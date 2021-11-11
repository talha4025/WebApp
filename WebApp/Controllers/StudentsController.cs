using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class StudentsController : Controller
    {
        IStudentsMap studentsMap;
        public StudentsController(IStudentsMap _studentsMap)
        {
            studentsMap = _studentsMap;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<StudentsViewModel>> Get()
        {
            return await studentsMap.GetAll();
        }

        [HttpGet("Search/{id}")]
        public Task<StudentsViewModel> Search(int id)
        {
            return studentsMap.Search(id);
        }

        [HttpPost("Create")]
        public Task<StudentsViewModel> Post([FromBody] StudentsViewModel student)
        {
            StudentsViewModel stud = student;
            return studentsMap.Create(stud);
        }
        
        [HttpPut("Update")]
        public Task<bool> Put([FromBody] StudentsViewModel student)
        {
            return studentsMap.Update(student);
        }
        
        [HttpDelete("Delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await studentsMap.Delete(id);
        }
    }
}
