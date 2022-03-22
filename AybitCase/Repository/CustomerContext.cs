using System;
using Microsoft.EntityFrameworkCore;
using AybitCase.Models;


namespace AybitCase.Repository
{
    public class CustomerContext: DbContext
    {
        public CustomerContext()
        {
        }
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HAMD7NO;Database=UserFirstDB;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>().ToTable("Customers");
        //}
    }
}
