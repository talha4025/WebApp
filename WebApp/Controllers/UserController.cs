using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UserController : Controller
    {
        IUserMap userMap;
        public UserController(IUserMap map)
        {
            userMap = map;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return userMap.GetAll();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody] string user)
        {
        }
        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string user)
        {
        }
        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
