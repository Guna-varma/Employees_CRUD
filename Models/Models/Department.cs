using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Model.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Location")]
        public string Location { get; set; }

        public List<DeptProject> DeptProjects { get; set; }

    }
}
