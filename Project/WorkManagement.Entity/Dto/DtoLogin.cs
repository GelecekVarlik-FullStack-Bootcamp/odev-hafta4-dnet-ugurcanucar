using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Base;

namespace WorkManagement.Entity.Dto
{
    public class DtoLogin:DtoBase
    {
        [Required]
        public string EmployeeEmail { get; set; }

        [Required] 
        public string EmployeePassword { get; set; }
        
    }
}
