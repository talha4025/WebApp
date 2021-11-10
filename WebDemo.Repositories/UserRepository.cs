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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IApplicationContext context)
            : base(context)
        { }

        public override User Save(User domain)
        {
            try
            {   
                var us = context.UserDB.Add(domain).Entity; //InsertUser<User>(domain);
                return us;
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                throw ex;
            }
        }
        public override bool Update(User domain)
        {
            try
            {
                //domain.Updated = DateTime.Now;
                context.UserDB.Update(domain);
                context.SaveChanges();
                //UpdateUser<User>(domain);
                return true;
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                throw ex;
            }
        }
        public override bool Delete(int id)
        {
            try
            {
                User user = context.UserDB.Where(x => x.Id.Equals(id)).FirstOrDefault();
                if (user != null)
                {

                    context.UserDB.Remove(user);
                    context.SaveChanges();
                    //Delete<User>(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                throw ex;
            }
        }
        public override List<User> GetAll()
        {
            try
            {
                return context.UserDB.OrderBy(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                throw ex;
            }
        }
    }
}
