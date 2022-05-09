using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Dto;
using WorkManagement.Entity.Models;

namespace WorkManagement.Dal.Abstract.IRepository
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        Employee Login(Employee employee);
        Employee Register(Employee employee,int userId);
        Employee ChangePassword(Employee employee,string oldPassword); 
        Employee ChangePass(Employee employee);


    }

}
