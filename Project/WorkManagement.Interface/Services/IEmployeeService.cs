using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Dto;
using WorkManagement.Entity.IBase;
using WorkManagement.Entity.Models;

namespace WorkManagement.Interface.Services
{
    public interface IEmployeeService : IGenericService<Employee, DtoEmployee>
    {
        IResponse<DtoEmployeeToken> Login(DtoLogin login);
        IResponse<DtoEmployee> ChangePass(DtoChangePassword changePassword, bool saveChanges = true); 
        IResponse<DtoEmployee> Register(DtoEmployee item,int userId, bool saveChanges = true);
        



    }
}
