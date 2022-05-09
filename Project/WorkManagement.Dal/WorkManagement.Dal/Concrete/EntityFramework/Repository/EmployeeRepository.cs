using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Dal.Abstract.IRepository;
using WorkManagement.Entity.Models;

namespace WorkManagement.Dal.Concrete.EntityFramework.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context)
        {

        }

        public Employee ChangePass(Employee employee)
        { 
            Employee newEmployee = employee;
            dbset.Update(newEmployee);
            return newEmployee;
        }

        public Employee ChangePassword(Employee employee, string oldPassword)
        {
            context.Entry(employee).State = EntityState.Modified; 
            dbset.Update(employee);
            return employee;
        }

        public Employee Login(Employee loginModel)
        {
            var employee = dbset.Where(x => x.EmployeeEmail == loginModel.EmployeeEmail && x.EmployeePassword == loginModel.EmployeePassword)
                .SingleOrDefault();

            return employee;
        }

        public Employee Register(Employee employee,int userId)
        {
          
                context.Entry(employee).State = EntityState.Added;
                dbset.Add(employee);

                return employee;
            
        }
    } 
}
