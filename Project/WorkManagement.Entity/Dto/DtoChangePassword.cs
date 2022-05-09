using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Base;

namespace WorkManagement.Entity.Dto
{
    public class DtoChangePassword : DtoBase
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string OldPassword { get; set; } 

        [Required]
        public string EmployeePassword { get; set; }
    }
}
