using BreakevenStoneDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BreakevenStoneInfra
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Product> Product { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*optionsBuilder
                .UseSqlServer(
                    "Data Source=localhost,1433;Initial Catalog=BreakevenStone;Integrated Security=False;User Id=sa;Password=Stone@2022!;Persist Security Info=True");*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}