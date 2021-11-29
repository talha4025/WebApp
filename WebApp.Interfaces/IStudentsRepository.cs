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
        Task<string> Delete(int id);
        Task<List<Students>> GetAll();

        Task<Students> Save(Students domain);
        Task<Students> Search(int id);
        Task<string> Update(Students domain);
    }
}
