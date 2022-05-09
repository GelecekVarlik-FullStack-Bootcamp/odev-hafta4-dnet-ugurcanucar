using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Base;

namespace WorkManagement.Entity.Dto
{
    public class DtoRequest:DtoBase
    {
        public int RequestId { get; set; }
        public int RequestDepartmentId { get; set; }
        public int RequestSubjectId { get; set; }
        public int RequestUrgencyId { get; set; }
        public DateTime? RequestStartDate { get; set; }
        public DateTime? RequestEndDate { get; set; }
        public string RequestMessage { get; set; }
        public string RequestTitle { get; set; }
    }
}
