using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Entity
{
    public class EmployeeMAnegmentSystemContext: DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<RequestState> RequestStates { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NRLBL9O\\SQLEXPRESS01;Database=EmployeeManagementSystemDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e=>e.department)
                .WithMany(d =>d.Employees)
                .HasForeignKey(e => e.DepartmentId);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId);

            modelBuilder.Entity<VacationRequest>()
                .HasOne(vr => vr.Employee)
                .WithMany(e => e.VacationRequests)
                .HasForeignKey(vr => vr.EmployeeNumber);
            modelBuilder.Entity<VacationRequest>()
                .HasOne(vr => vr.VacationType)
                .WithMany(vt => vt.VacationRequests)
                .HasForeignKey(vr => vr.VacationTypeCode);
            modelBuilder.Entity<VacationRequest>()
                .HasOne(vr => vr.RequestState)
                .WithMany(rs => rs.VacationRequests)
                .HasForeignKey(vr => vr.RequestStateId);



        }


    }
}
