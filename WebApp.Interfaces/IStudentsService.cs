using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Models;
using WebDemo.ViewModels;

namespace WebApp.Interfaces
{
    public interface IStudentsService
    {
        Task<StudentsViewModel> Create(StudentsViewModel viewModel);
        Task<string> Delete(int id);
        Task<List<StudentsViewModel>> GetAll();
        Task<StudentsViewModel> Search(int id);
        Task<string> Update(StudentsViewModel domain);
    }
}
