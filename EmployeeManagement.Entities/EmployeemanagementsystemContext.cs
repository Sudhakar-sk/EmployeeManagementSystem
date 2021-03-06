// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmployeeManagement.Entities
{
    public partial class EmployeemanagementsystemContext : DbContext
    {
        public EmployeemanagementsystemContext()
        {
        }

        public EmployeemanagementsystemContext(DbContextOptions<EmployeemanagementsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee_Details> Employee_Details { get; set; }
        public virtual DbSet<admin_Login> admin_Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeManagementSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee_Details>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Created_Time_Stamp).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Department).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Full_Name).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.Matricule).IsUnicode(false);

                entity.Property(e => e.Updated_Time_Stamp).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.User_Name).IsUnicode(false);
            });

            modelBuilder.Entity<admin_Login>(entity =>
            {
                entity.Property(e => e.Created_Time_Stamp).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted_Time_Stamp).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.User_Name).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}