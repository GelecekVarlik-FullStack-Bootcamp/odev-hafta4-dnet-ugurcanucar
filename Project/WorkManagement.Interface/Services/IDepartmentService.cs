using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Dto;
using WorkManagement.Entity.Models;

namespace WorkManagement.Interface.Services
{
    public interface IDepartmentService : IGenericService<Department, DtoDepartment>
    {
        //Special Service Methods
    }

    
}
