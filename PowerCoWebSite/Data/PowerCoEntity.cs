namespace PowerCoWebSite.Data
{
    using PowerCo.Model;
    using PowerCoWebSite.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PowerCoEntity : DbContext
    {
        public PowerCoEntity()
            : base("name=PowerCoEntity")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Deprtments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}