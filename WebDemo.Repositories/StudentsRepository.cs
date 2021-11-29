using Microsoft.EntityFrameworkCore;
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

        public async Task<string> Delete(int id)
        {
            try
            {
                Students student= await context.StudentsDB.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
                if (student != null)
                {

                    context.StudentsDB.Remove(student);
                    context.SaveChanges();
                    return $"Student with ID: {student.Id} and Name: {student.FirstName +" "+ student.LastName} Deleted from Records";
                }
                else
                {
                    return "Student not Found in database";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Students>> GetAll()
        {
            try
            {
                return  await context.StudentsDB.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Students> Search(int id)
        {
            try
            {
                Students student = await context.StudentsDB.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
                return student;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Students> Save(Students domain)
        {
            try
            {
                var us = await context.StudentsDB.AddAsync(domain);
                context.SaveChanges();
                return us.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Update(Students domain)
        {
            try 
            {
                var student =await context.StudentsDB.AsNoTracking().Where(x => x.Id.Equals(domain.Id)).FirstOrDefaultAsync() ;
                if (student!=null)
                {

                    student.FirstName = domain.FirstName;
                    student.LastName = domain.LastName;
                    student.Gender = domain.Gender;
                    student.Address = domain.Address;
                    student.ContactInfo = domain.ContactInfo;
                    student.Department = domain.Department;
                    student.CGPA = domain.CGPA;

                    //context.StudentsDB.Update(domain);
                    context.SaveChanges();
                    return $"Student with ID: {domain.Id} Updated in Database Records";
                }
                else
                {
                    return "Student not Found in database";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
