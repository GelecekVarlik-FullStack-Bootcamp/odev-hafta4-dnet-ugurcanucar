using System;
using System.Collections.Generic;

#nullable disable

namespace WorkManagement.Entity.Models
{
    public partial class Authorization
    {
        public Authorization()
        {
            Employees = new HashSet<Employee>();
        }

        public int Authorizationd { get; set; }
        public string AuthorizationName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
