using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VayanaProjectDataModels;

#nullable disable

namespace VayanaProjectRepository
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QNDUQ9R;Initial Catalog=VayanaProj;User ID=anku_user;Password=anku_user");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__Departme__72ABC2CC21D9A701");

                entity.ToTable("Department");

                entity.Property(e => e.DeptId).HasColumnName("Dept_Id");

                entity.Property(e => e.DeptCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Dept_Code");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Dept_Name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__262359AB794A1DF8");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.EmpCreatedBy).HasColumnName("Emp_CreatedBy");

                entity.Property(e => e.EmpCreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Emp_CreatedOn");

                entity.Property(e => e.EmpDeptId).HasColumnName("Emp_DeptId");

                entity.Property(e => e.EmpFirstName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Emp_FirstName");

                entity.Property(e => e.EmpIsActive)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Emp_IsActive");

                entity.Property(e => e.EmpIsDeleted).HasColumnName("Emp_IsDeleted");

                entity.Property(e => e.EmpLastName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Emp_LastName");

                entity.Property(e => e.EmpMiddleName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Emp_MiddleName");

                entity.Property(e => e.EmpModifiedBy).HasColumnName("Emp_ModifiedBy");

                entity.Property(e => e.EmpModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Emp_ModifiedOn");

                entity.Property(e => e.EmpSalary).HasColumnName("Emp_Salary");

                entity.HasOne(d => d.EmpDept)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmpDeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Department");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
