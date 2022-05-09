using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Dal.Abstract.IRepository;
using WorkManagement.Entity.Dto;
using WorkManagement.Entity.Models;
using WorkManagement.Interface.Services;

namespace WorkManagement.Bll.Managers
{
    public class DepartmentManager : GenericManager<Department, DtoDepartment>, IDepartmentService
    {

        public readonly IDepartmentRepository departmentRepository;
        public DepartmentManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            departmentRepository = serviceProvider.GetService<IDepartmentRepository>();
        }


    }
     
}
