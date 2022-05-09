using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Base;

namespace WorkManagement.Entity.Dto
{
    public class DtoEmployee:DtoBase
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeePhone { get; set; }
        public int EmployeeDepartmentId { get; set; }
        public int EmployeeAuthorizationId { get; set; }
    }
}
