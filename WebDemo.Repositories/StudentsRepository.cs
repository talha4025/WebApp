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

        public async Task<bool> Delete(int id)
        {
            try
            {
                Students student= await context.StudentsDB.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
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

        public async Task<bool> Update(Students domain)
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
