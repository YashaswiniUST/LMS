using LMS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        
        public DbSet<Student> Students{get;set;}
        public DbSet<Issue> Issues{get;set;}
        public DbSet<Book> Books{get;set;}
        public DbSet<Admin> Admins{get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Issue>()
        .HasKey(i => i.IssueId);

    modelBuilder.Entity<Issue>()
        .Property(i => i.IssueId)
        .ValueGeneratedOnAdd();
}

    }
}