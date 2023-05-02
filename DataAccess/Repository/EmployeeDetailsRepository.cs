using Emp.DataAccess.Data;
using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DataAccess.Repository
{
    public class EmployeeDetailsRepository : Repository<EmployeeDetails>, IEmployeeDetailsRepository
    {
        public ApplicationDbContext _db;

        public EmployeeDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EmployeeDetails employeeDetails)
        {
            _db.employeeDetailsList.Update(employeeDetails);
        }

    }
}
