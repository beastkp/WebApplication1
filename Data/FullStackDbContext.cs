using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class FullStackDbContext: DbContext 
    {
        public FullStackDbContext(DbContextOptions options) : base(options)
        //DBcontextOptions parameter in the constructor contains the configuration information required by
        // DBcontext to connect to the database, connectionstring, base(options) is a call to the base class 
        // constructors passing the options parameters 
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
