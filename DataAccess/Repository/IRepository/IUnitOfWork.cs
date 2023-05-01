using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBankDetailsRepository bankDetails { get; }
        IProjectRepository project { get; }
        IEmployeeDetailsRepository employeeDetails { get; }
        IDepartmentRepository department { get; }

        void Save();
    }
}
