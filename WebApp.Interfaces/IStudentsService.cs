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
        Task<Students> Create(Students domain);
        Task<bool> Delete(int id);
        Task<List<Students>> GetAll();
        Task<Students> Search(int id);
        Task<bool> Update(Students domain);
    }
}
