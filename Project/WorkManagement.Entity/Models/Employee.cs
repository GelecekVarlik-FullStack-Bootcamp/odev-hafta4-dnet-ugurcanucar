using System;
using System.Collections.Generic;
using WorkManagement.Entity.Base;

#nullable disable

namespace WorkManagement.Entity.Models
{
    public partial class Employee:EntityBase
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeePhone { get; set; }
        public int EmployeeDepartmentId { get; set; }
        public int EmployeeAuthorizationId { get; set; }

        public virtual Authorization EmployeeAuthorization { get; set; }
        public virtual Department EmployeeDepartment { get; set; }
    }
}
