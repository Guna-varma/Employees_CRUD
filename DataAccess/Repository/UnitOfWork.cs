
using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
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

        public IDepartmentRepository Category { get; set; }
        public IProjectRepository Product { get; set; }

        public IBankDetailsRepository bankDetails => throw new NotImplementedException();

        public IProjectRepository project => throw new NotImplementedException();

        public IEmployeeDetailsRepository employeeDetails => throw new NotImplementedException();

        public IDepartmentRepository department => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            Category = new EmployeeDetailsRepository(_db);

            Product = new DepartmentRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
