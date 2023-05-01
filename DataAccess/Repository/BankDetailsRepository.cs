using Emp.DataAccess.Repository.IRepository;
using Emp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DataAccess.Repository
{
    public class BankDetailsRepository : Repository<BankDetails>, IBankDetailsRepository
    {
        public ApplicationDbContext _db;

        public BankDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BankDetails bankDetails)
        {
            _db.bankDetailsList.Update(bankDetails);
        }

    }
}
