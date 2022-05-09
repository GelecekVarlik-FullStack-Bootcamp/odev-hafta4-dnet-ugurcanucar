using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Dto;

namespace WorkManagement.Bll.Helpers
{
    public class TokenManager
    {
        IConfiguration configuration;
        public TokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string CreateAccessToken(DtoLoginEmployee employee)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,employee.EmployeeName),
                new Claim(JwtRegisteredClaimNames.Sub,employee.EmployeeSurName),
                new Claim(JwtRegisteredClaimNames.Jti,employee.EmployeeId.ToString()),
            };

            var claimIdentity = new ClaimsIdentity(claims, "Token");

            var claimsRoleList = new List<Claim>
            {
                new Claim("Role","Admin"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: configuration["Tokens:Issuer"],
                audience: configuration["Tokens:Issuer"],
                expires: DateTime.Now.AddDays(1),
                notBefore: DateTime.Now,
                signingCredentials: cred,
                claims: claimIdentity.Claims

             );
            
            var tokenHandler= new {token=new JwtSecurityTokenHandler().WriteToken(token)};

            return tokenHandler.token;

        }
    }
}
