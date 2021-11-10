using Microsoft.EntityFrameworkCore;

namespace WebDemo.Models.Context
{
    public interface IApplicationContext
    {
        DbSet<User> UserDB { get; set; }
        DbSet<Students> StudentsDB { get; set; }

        void BeginTransaction();
        void CommitTransaction();
        void DisposeTransaction();
        void RollbackTransaction();
        void SaveChanges();
        DbSet<T> Set<T>() where T : class;
    }
}