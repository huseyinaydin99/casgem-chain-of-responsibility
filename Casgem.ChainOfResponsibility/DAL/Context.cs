using Microsoft.EntityFrameworkCore;

namespace Casgem.ChainOfResponsibility.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-13123BI; initial catalog = CasgemDBDesingPattern; integrated security = true;");
        }

        public DbSet<CustomerProcess> CustomerProcess { get; set; }
    }
}
