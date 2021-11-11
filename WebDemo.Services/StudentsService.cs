using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Interfaces;
using WebDemo.Models;

namespace WebDemo.Services
{
    public class StudentsService: IStudentsService
    {
        private IStudentsRepository studentsRepository;
        public StudentsService(IStudentsRepository _studentsRepository)
        {
            studentsRepository = _studentsRepository;
        }

        public async Task<Students> Create(Students domain)
        {
            return await studentsRepository.Save(domain);
        }
        public async Task<bool> Update(Students domain)
        {
            return await studentsRepository.Update(domain);
        }
        public async Task<bool> Delete(int id)
        {
            return await studentsRepository.Delete(id);
        }
        public async Task<List<Students>> GetAll()
        {
            return await studentsRepository.GetAll();
        }
        public async Task<Students> Search(int id)
        {
            return await studentsRepository.Search(id);
        }
    }
}
