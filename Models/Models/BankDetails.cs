using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Model.Models
{
    public class BankDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Account Number")]
        public string AccountNo { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("IFSC Code")]
        public string IFSCCode { get; set; }

        [Required]
        [DisplayName("Branch Name")]
        public string Branch { get; set; }
    }
}
