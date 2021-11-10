using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Models;
using WebDemo.ViewModels;

namespace WebApp.Interfaces
{
    public interface IStudentsMap
    {
        StudentsViewModel Create(StudentsViewModel viewModel);
        bool Delete(int id);
       
        List<StudentsViewModel> GetAll();
        StudentsViewModel Search(int id);
        bool Update(StudentsViewModel viewModel);

        StudentsViewModel DomainToViewModel(Students domain);
        List<StudentsViewModel> DomainToViewModel(List<Students> domain);
        Students ViewModelToDomain(StudentsViewModel officeViewModel);
    }
}
