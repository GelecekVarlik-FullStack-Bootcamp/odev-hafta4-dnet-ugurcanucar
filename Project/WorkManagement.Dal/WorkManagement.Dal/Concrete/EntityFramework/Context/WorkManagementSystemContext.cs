using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using WorkManagement.Entity.Models;

#nullable disable

namespace WorkManagement.Dal.Concrete.EntityFramework.Context.WorkManagementSystemContext
{
    public partial class WorkManagementSystemContext : DbContext
    {
        IConfiguration configuration;
        public WorkManagementSystemContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //public WorkManagementSystemContext(DbContextOptions<WorkManagementSystemContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Urgency> Urgencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=UGURCAN;Database=WorkManagementSystem;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Authorization>(entity =>
            {
                entity.HasKey(e => e.Authorizationd);

                entity.ToTable("Authorization");

                entity.Property(e => e.AuthorizationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePassword)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePhone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeSurName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeAuthorization)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeAuthorizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Authorization");

                entity.HasOne(d => d.EmployeeDepartment)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeDepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.RequestEndDate).HasColumnType("date");

                entity.Property(e => e.RequestMessage)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RequestStartDate).HasColumnType("date");

                entity.Property(e => e.RequestTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RequestDepartment)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.RequestDepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Department");

                entity.HasOne(d => d.RequestUrgency)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.RequestUrgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Urgency");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Urgency>(entity =>
            {
                entity.ToTable("Urgency");

                entity.Property(e => e.UrgencyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
