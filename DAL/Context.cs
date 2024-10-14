using Microsoft.EntityFrameworkCore;

namespace ChainOfResponsibilityDesingPattern.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=NB-230103\\SQLEXPRESS;initial catalog=ChainOfResponsibility;integrated security=true;");
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
