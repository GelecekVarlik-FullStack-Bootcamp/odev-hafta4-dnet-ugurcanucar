

#nullable disable

using WorkManagement.Entity.Base;

namespace WorkManagement.Entity.Dto
{
    public partial class DtoDepartment:DtoBase
    {
        public DtoDepartment()
        {
      
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
         
    }
}
