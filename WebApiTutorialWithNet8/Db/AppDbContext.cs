using Microsoft.EntityFrameworkCore;
using WebApiTutorialWithNet8.Model;

namespace WebApiTutorialWithNet8.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> db):base(db)
        {
                
        }

        public DbSet<Customer> Customers { get; set; }  
    }
}
