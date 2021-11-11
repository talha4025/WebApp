using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Interfaces;
using WebDemo.Models;
using WebDemo.ViewModels;

namespace WebDemo.Maps
{
    public class StudentsMap: IStudentsMap
    {
        private IStudentsService studentsService;
        public StudentsMap(IStudentsService _studentsService)
        {
            studentsService = _studentsService;
        }
        public async Task<StudentsViewModel> Create(StudentsViewModel viewModel)
        {
            Students student = ViewModelToDomain(viewModel);
            return DomainToViewModel(await studentsService.Create(student));
        }
        public async Task<bool> Update(StudentsViewModel viewModel)
        {
            Students student = ViewModelToDomain(viewModel);
            return await studentsService.Update(student);
        }
        public async Task<bool> Delete(int id)
        {
            return await studentsService.Delete(id);
        }
        public async Task<List<StudentsViewModel>> GetAll()
        {
            return DomainToViewModel(await studentsService.GetAll());
        }
        public async Task<StudentsViewModel> Search(int id)
        {
            return DomainToViewModel(await studentsService.Search(id));
        }
        public StudentsViewModel DomainToViewModel(Students domain)
        {
            StudentsViewModel model = new StudentsViewModel();
            model.Id = domain.Id;
            model.FirstName = domain.FirstName;
            model.LastName = domain.LastName;
            model.Department = domain.Department;
            model.ContactInfo = domain.ContactInfo;
            model.Gender = domain.Gender;
            model.CGPA = domain.CGPA;
            model.Address = domain.Address;
            return model;
        }
        public List<StudentsViewModel> DomainToViewModel(List<Students> domain)
        {
            List<StudentsViewModel> model = new List<StudentsViewModel>();
            foreach (Students stds in domain)
            {
                model.Add(DomainToViewModel(stds));
            }
            
            return model;
        }
        public Students ViewModelToDomain(StudentsViewModel officeViewModel)
        {
            Students domain = new Students();
            if (officeViewModel.Id != 0 && officeViewModel.Id != null)
            {
                domain.Id = officeViewModel.Id;
            }
            domain.FirstName = officeViewModel.FirstName;
            domain.LastName = officeViewModel.LastName;
            domain.Department = officeViewModel.Department;
            domain.ContactInfo = officeViewModel.ContactInfo;
            domain.Gender = officeViewModel.Gender;
            domain.CGPA = officeViewModel.CGPA;
            domain.Address = officeViewModel.Address;
            return domain;
        }
    }
}
