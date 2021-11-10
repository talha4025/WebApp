using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Interfaces;
using WebDemo.Models;
using WebDemo.Models.Context;

namespace WebDemo.Repositories
{
    public class StudentsRepository: IStudentsRepository
    {
        private IApplicationContext context;
        public StudentsRepository(IApplicationContext _context)
        {
            context = _context;
        }

        public bool Delete(int id)
        {
            try
            {
                Students student= context.StudentsDB.Where(x => x.Id.Equals(id)).FirstOrDefault();
                if (student != null)
                {

                    context.StudentsDB.Remove(student);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Students> GetAll()
        {
            try
            {
                return context.StudentsDB.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Students Search(int id)
        {
            try
            {
                Students student = context.StudentsDB.Where(x => x.Id.Equals(id)).FirstOrDefault();
                return student;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Students Save(Students domain)
        {
            try
            {
                var us = context.StudentsDB.Add(domain);
                context.SaveChanges();
                return us.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Students domain)
        {
            try
            {
                context.StudentsDB.Update(domain);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
