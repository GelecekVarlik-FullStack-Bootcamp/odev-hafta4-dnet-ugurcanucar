using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Base;

namespace WorkManagement.Entity.Dto
{
    public class DtoLoginEmployee:DtoBase
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurName { get; set; }
        public string EmployeeEmail { get; set; } 
        public string EmployeePhone { get; set; }
        public string EmployeeDepartment { get; set; }
        public int EmployeeAuthorization { get; set; }
    }
}
