using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    public class RequestController : ApiBaseController<IRequestService, Request, DtoRequest>
    {
        private readonly IRequestService requestService;
        public RequestController(IRequestService requestService) : base(requestService)
        {
            this.requestService = requestService;
        }


        [HttpGet("GetByDepartmentId")] 
        public IResponse<List<DtoRequest>> GetAll(int departmentId)
        {
            try
            {
                 
                return requestService.GetAll(a=>a.RequestDepartmentId==departmentId);
            }
            catch (Exception ex)
            {

                return new Response<List<DtoRequest>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : ${ex.Message}",
                    Data = null
                };
            }
        }


    }
    
}
