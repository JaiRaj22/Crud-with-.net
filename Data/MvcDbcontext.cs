using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Domain;

namespace WebApplication1.Data
{
    public class MvcDbcontext : DbContext
    {
        public MvcDbcontext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasColumnType("uuid") // Configure the column type as uuid
                .IsRequired();

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
