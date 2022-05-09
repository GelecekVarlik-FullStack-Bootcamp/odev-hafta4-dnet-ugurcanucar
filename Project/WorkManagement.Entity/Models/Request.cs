using System;
using System.Collections.Generic;
using WorkManagement.Entity.Base;

#nullable disable

namespace WorkManagement.Entity.Models
{
    public partial class Request:EntityBase
    {
        public int RequestId { get; set; }
        public int RequestDepartmentId { get; set; }
        public int RequestSubjectId { get; set; }
        public int RequestUrgencyId { get; set; }
        public DateTime? RequestStartDate { get; set; }
        public DateTime? RequestEndDate { get; set; }
        public string RequestMessage { get; set; }
        public string RequestTitle { get; set; }

        public virtual Department RequestDepartment { get; set; }
        public virtual Urgency RequestUrgency { get; set; }
    }
}
