using Emp.Model.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Model.ViewModels
{
    public class EmpDetailsVM
    {
        public EmployeeDetails EmployeeDetails { get; set; }
        
        [ValidateNever]
        public IEnumerable<SelectListItem> DeptList { get; set; }
    }
}
