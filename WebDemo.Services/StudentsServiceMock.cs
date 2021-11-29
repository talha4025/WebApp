using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Interfaces;
using WebDemo.Models;
using WebDemo.Models.Context;
using WebDemo.Repositories;
using WebDemo.ViewModels;

namespace WebDemo.Services
{
    public class StudentsServiceMock : IStudentsService
    {
        private IApplicationContext context;
        private IStudentsRepository studentsRepository;
        public StudentsServiceMock()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase(databaseName:"StudentDB");
            context = new ApplicationContext(optionsBuilder.Options);
            studentsRepository = new StudentsRepository(context);

        }
        public async Task<StudentsViewModel> Create(StudentsViewModel viewModel)
        {
            Students domain = ViewModelToDomain(viewModel);
            var us = await studentsRepository.Save(domain);
            return DomainToViewModel(us);
        }

        public async Task<string> Delete(int id)
        {
            return await studentsRepository.Delete(id);
        }

        public async Task<List<StudentsViewModel>> GetAll()
        {
            List<Students> students = await studentsRepository.GetAll();
            return DomainToViewModel(students);
        }

        public async Task<StudentsViewModel> Search(int id)
        {
            Students student = await studentsRepository.Search(id);
            return DomainToViewModel(student);

        }

        public async Task<string> Update(StudentsViewModel model)
        {
            Students domain = ViewModelToDomain(model);
            return await studentsRepository.Update(domain);
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
