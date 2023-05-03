using Emp.Model.Models;
using Microsoft.EntityFrameworkCore;


namespace Emp.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<EmployeeDetails> employeeDetailsList { get; set; }
        public DbSet<BankDetails> bankDetailsList { get; set; }
        public DbSet<Project> projectsList { get; set; }
        public DbSet<Department> departmentList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankDetails>().HasData(
                new BankDetails { Id = 1, AccountNo = "1234567890", Branch = "HYD", IFSCCode = "SBIN0000967", EmployeeId=1 }
                );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, ProjectLead = "Shiva", projectName = "xNet" }
                );

            modelBuilder.Entity<EmployeeDetails>().HasData(
                new EmployeeDetails { Id = 1, EmployeeCode = "22060023", FirstName = "Guna", LastName = "Varma",DepartmentId=1}
                );

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, DepartmentName = "Digital", Location = "Gurgaon" }
                );

            //modelBuilder.Entity<EmployeeProject>().HasKey(p => new { p.ProjectId, p.EmployeeId });

            //modelBuilder.Entity<EmployeeProject>().
            //    HasOne(p=>p.Project).WithMany(p=>p.EmployeeProjects).HasForeignKey(p=>p.ProjectId);

            //modelBuilder.Entity<EmployeeProject>().
            //    HasOne(p => p.EmployeeDetails).WithMany(p => p.EmployeeProjects).HasForeignKey(p => p.EmployeeId);
   
        }
    }
}