using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Models;

namespace WebApp.Interfaces
{
    public interface IStudentsService
    {
        Students Create(Students domain);
        bool Delete(int id);
        List<Students> GetAll();
        Students Search(int id);
        bool Update(Students domain);
    }
}
