using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Models;

namespace WebApp.Interfaces
{
    public interface IUserRepository
    {
        bool Delete(int id);
        List<User> GetAll();
        User Save(User domain);
        bool Update(User domain);
    }
}
