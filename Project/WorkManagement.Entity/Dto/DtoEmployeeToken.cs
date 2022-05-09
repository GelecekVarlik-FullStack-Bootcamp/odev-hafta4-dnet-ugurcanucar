using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkManagement.Entity.Dto
{
    public class DtoEmployeeToken
    {
        public DtoLoginEmployee DtoLoginEmployee { get; set; }

        public object AccessToken { get; set; }
    }
}
