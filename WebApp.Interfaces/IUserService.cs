using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Models;

namespace WebApp.Interfaces
{
    public interface IUserService
    {
        User Create(User domain);
        bool Delete(int id);
        List<User> GetAll();
        bool Update(User domain);
    }
}
