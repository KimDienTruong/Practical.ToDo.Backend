using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(x=> x.UserName);

            modelBuilder.Entity<ToDoTask>()
                .HasOne(x => x.User)
                .WithMany(x => x.ToDoTasks)
                .HasForeignKey(x => x.UserName)
                .IsRequired();
        }
    }
}
