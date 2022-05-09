using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Bll.Helpers;
using WorkManagement.Dal.Abstract.IRepository;
using WorkManagement.Entity.Base;
using WorkManagement.Entity.Dto;
using WorkManagement.Entity.IBase;
using WorkManagement.Entity.Models;
using WorkManagement.Interface.Services;

namespace WorkManagement.Bll.Managers
{
    public class EmployeeManager : GenericManager<Employee, DtoEmployee>, IEmployeeService
    {

        public readonly IEmployeeRepository employeeRepository;
        private IConfiguration configuration;
        public EmployeeManager(IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider)
        {
            employeeRepository = serviceProvider.GetService<IEmployeeRepository>();
            this.configuration = configuration;
        }

        public IResponse<DtoEmployee> ChangePass(DtoChangePassword changePassword, bool saveChanges = true)
        {
            try
            {

                var entity = employeeRepository.Find(changePassword.EmployeeId);

                if(entity == null)
                {
                    return new Response<DtoEmployee>
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = $"Böyle bir kullanıcı yok.",
                        Data = null
                    };
                }
                else if (entity.EmployeePassword != changePassword.OldPassword)
                {
                    return new Response<DtoEmployee>
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = $"Şifreler uyumsuz.",
                        Data = null
                    };
                }
                entity.EmployeePassword = changePassword.EmployeePassword; 


                var result = employeeRepository.Update(entity);

                if (saveChanges)
                    Save();

                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<DtoEmployee>(result)
                };




            }
            catch (Exception ex)
            {

                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<DtoEmployee> ChangePassword(DtoEmployee item, string oldPassword, bool saveChanges = true)
        {
            try
            {
                var entity = employeeRepository.Find(item.EmployeeId);
                if (entity.EmployeePassword != oldPassword)
                {
                    return new Response<DtoEmployee>
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = "Old Password doesn't correct!",
                        Data = null
                    };
                }

                var model = ObjectMapper.Mapper.Map<Employee>(item);
               
                var result = employeeRepository.ChangePassword(model,oldPassword);

                if (saveChanges)
                    Save();

                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<DtoEmployee>(result)
                };




            }
            catch (Exception ex)
            {

                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<DtoEmployeeToken> Login(DtoLogin login)
        {
            var employee = employeeRepository.Login(ObjectMapper.Mapper.Map<Employee>(login));


            if (employee != null)
            {
                var dtoEmployee = ObjectMapper.Mapper.Map<DtoLoginEmployee>(employee);
                var token = new TokenManager(configuration).CreateAccessToken(dtoEmployee);


                var userToken = new DtoEmployeeToken()
                {
                    DtoLoginEmployee = dtoEmployee,
                    AccessToken = token,
                };
                return new Response<DtoEmployeeToken>
                {
                    Data = userToken,
                    Message = "Token Üretildi.",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new Response<DtoEmployeeToken>
                {
                    Message = "Email veya parola yanlış",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };

            }
        }

        public IResponse<DtoEmployee> Register(DtoEmployee item,int userId, bool saveChanges = true)
        {
            try
            { 
                var author = employeeRepository.Find(userId); 

                if(author.EmployeeAuthorizationId!=1&& author.EmployeeAuthorizationId != 2 )
                { 
                    return new Response<DtoEmployee>
                    {
                        StatusCode = StatusCodes.Status406NotAcceptable,
                        Message = "Kayıt edecek kullanıcının yetkisi yetersiz!",
                        Data = null
                    };
                }

                var model = ObjectMapper.Mapper.Map<Employee>(item);
                var result = employeeRepository.Register(model,userId);

                if (saveChanges)
                    Save();

                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<DtoEmployee>(result)
                };




            }
            catch (Exception ex)
            {

                return new Response<DtoEmployee>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error : {ex.Message}",
                    Data = null
                };
            }
        }
    }



}
