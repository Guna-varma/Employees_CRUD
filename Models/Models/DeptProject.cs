using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Model.Models
{
    public class DeptProject
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
 