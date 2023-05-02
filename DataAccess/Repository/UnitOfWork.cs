
using Emp.DataAccess.Data;
using Emp.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db;

        public IDepartmentRepository department { get; set; }
        public IProjectRepository project { get; set; }
        public IEmployeeDetailsRepository employeeDetails { get; set; }
        public IBankDetailsRepository bankDetails { get; set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            employeeDetails = new EmployeeDetailsRepository(_db);

            department = new DepartmentRepository(_db);

            bankDetails = new BankDetailsRepository(_db);

            project = new ProjectRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
