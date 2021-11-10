using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Models;

namespace WebApp.Interfaces
{
    public interface IStudentsRepository
    {
        public bool Delete(int id);
        public List<Students> GetAll();

        public Students Save(Students domain);
        Students Search(int id);
        public bool Update(Students domain);
    }
}
