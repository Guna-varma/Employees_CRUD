using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Model.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Project Name")]
        public string projectName { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Project Lead")]
        public string ProjectLead { get; set; }

        public List<DeptProject> DeptProjects { get; set; }

    }
}
