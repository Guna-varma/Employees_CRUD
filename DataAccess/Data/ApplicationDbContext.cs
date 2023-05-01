using Emp.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace Emp.Model.Models
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
                new BankDetails { Id = 1, AccountNo = "1234567890", Branch = "HYD", IFSCCode = "SBIN0000967"},
                new BankDetails { Id = 2, AccountNo = "9876544323", Branch = "DEL", IFSCCode = "KKBK0987633"},
                new BankDetails { Id = 3, AccountNo = "0987654321", Branch = "RPR", IFSCCode = "KKBK09889455"},
                new BankDetails { Id = 4, AccountNo = "5678901234", Branch = "TDD", IFSCCode = "HDFC90889455" }
                );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, ProjectLead = "Shiva", projectName = "xNet" }
                );

            modelBuilder.Entity<EmployeeDetails>().HasData(
                new EmployeeDetails { Id = 1, EmployeeCode = "22060023",  FirstName= "Guna", LastName= "Varma"}
                );

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, DepartmentName="DIgital",Location ="Gurgaon" }
                );
        } 
    }
}