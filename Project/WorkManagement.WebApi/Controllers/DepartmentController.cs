using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkManagement.Entity.Dto;
using WorkManagement.Entity.Models; 
using WorkManagement.Interface.Services;
using WorkManagement.WebApi.Base;

namespace WorkManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ApiBaseController<IDepartmentService, Department, DtoDepartment>
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService) : base(departmentService)
        {
            this.departmentService = departmentService;
        }


    }
    
}
