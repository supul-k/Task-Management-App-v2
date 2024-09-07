using Microsoft.EntityFrameworkCore;
using Task_Management_App_V2.Models;

namespace Task_Management_App_V2.DbAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AssignmentModel> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>()
                .HasMany(a => a.Assignments)
                .WithOne(a => a.Users)
                .HasForeignKey(a => a.UserId)
                .HasPrincipalKey(a => a.UserId);
        }

    }
}
