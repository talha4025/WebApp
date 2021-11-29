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
        IStudentsService studentsService;
        public StudentsController(IStudentsService _studentsService)
        {
            studentsService = _studentsService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<StudentsViewModel>> Get()
        {
            return await studentsService.GetAll();
        }

        [HttpGet("Search/{id}")]
        public Task<StudentsViewModel> Search(int id)
        {
            return studentsService.Search(id);
        }

        [HttpPost("Create")]
        public Task<StudentsViewModel> Post([FromBody] StudentsViewModel student)
        {
            StudentsViewModel stud = student;
            return studentsService.Create(stud);
        }

        [HttpPut("Update")]
        public Task<string> Put([FromBody] StudentsViewModel student)
        {
            return studentsService.Update(student);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<string> Delete(int id)
        {
            return await studentsService.Delete(id);
        }
    }
}
