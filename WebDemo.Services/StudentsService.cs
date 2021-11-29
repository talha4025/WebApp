using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Interfaces;
//using WebDemo.Maps;
using WebDemo.Models;
using WebDemo.ViewModels;

namespace WebDemo.Services
{
    public class StudentsService: IStudentsService
    {
        private IStudentsRepository studentsRepository;
        public StudentsService(IStudentsRepository _studentsRepository)
        {
            studentsRepository = _studentsRepository;
        }

        public async Task<StudentsViewModel> Create(StudentsViewModel viewModel)
        {
            Students domain = ViewModelToDomain(viewModel);
            return DomainToViewModel(await studentsRepository.Save(domain));
        }
        public async Task<string> Update(StudentsViewModel viewModel)
        {
            return await studentsRepository.Update(ViewModelToDomain(viewModel));
        }
        public async Task<string> Delete(int id)
        {
            return await studentsRepository.Delete(id);
        }
        public async Task<List<StudentsViewModel>> GetAll()
        {
            return DomainToViewModel(await studentsRepository.GetAll());
        }
        public async Task<StudentsViewModel> Search(int id)
        {
            return DomainToViewModel(await studentsRepository.Search(id));
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
