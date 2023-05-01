using Emp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DataAccess.Repository.IRepository
{
    public interface IBankDetailsRepository : IRepository<BankDetails>
    {
        void Update(BankDetails bankDetails);
    }
}
