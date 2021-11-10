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

        public Students Create(Students domain)
        {
            return studentsRepository.Save(domain);
        }
        public bool Update(Students domain)
        {
            return studentsRepository.Update(domain);
        }
        public bool Delete(int id)
        {
            return studentsRepository.Delete(id);
        }
        public List<Students> GetAll()
        {
            return studentsRepository.GetAll();
        }
        public Students Search(int id)
        {
            return studentsRepository.Search(id);
        }
    }
}
