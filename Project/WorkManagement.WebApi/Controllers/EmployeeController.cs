using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using WorkManagement.Entity.Base;
using WorkManagement.Entity.Dto;
using WorkManagement.Entity.IBase;
using WorkManagement.Entity.Models;
using WorkManagement.Interface.Services;
using WorkManagement.WebApi.Base;

namespace WorkManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ApiBaseController<IEmployeeService, Employee, DtoEmployee>
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IResponse<DtoEmployeeToken> Login(DtoLogin login)
        {
            try
            {

                return employeeService.Login(login);
            }
            catch (Exception ex)
            {

                return new Response<DtoEmployeeToken>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        [HttpPost("Register")] 
        public IResponse<DtoEmployee> Register(DtoEmployee login,[Required] int userId)
        {
            try
            {
               
                
                return employeeService.Register(login,userId);
            }
            catch (Exception ex)
            {

                return new Response<DtoEmployee>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }



        [HttpPut("ChangePassword")]
        public IResponse<DtoEmployee> ChangePass(DtoChangePassword model)
        {
            try
            {
                return employeeService.ChangePass(model);
            }
            catch (Exception ex)
            {

                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : ${ex.Message}",
                    Data = null
                };
            }
        }


    }
}
