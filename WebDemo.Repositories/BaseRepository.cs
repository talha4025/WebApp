using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Models;
using WebDemo.Models.Context;

namespace WebDemo.Repositories
{
    public abstract class BaseRepository
    {
        protected IApplicationContext context;

        protected BaseRepository(IApplicationContext _context)
        {
            context = _context;
        }

       
        public abstract bool Delete(int id);
        public abstract List<User> GetAll();
        public abstract User Save(User domain);
        public abstract bool Update(User domain);
    }
}
