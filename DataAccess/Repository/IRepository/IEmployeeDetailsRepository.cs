using Emp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DataAccess.Repository.IRepository
{
    public interface IEmployeeDetailsRepository : IRepository<EmployeeDetails>
    {
        void Update(EmployeeDetails employeeDetails);
    }
}
