using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Auth;
using Application.GeneralResponses;
using Application.Interfaces.Services;
using Domain.Models;
using Infrastructure.Auth;
using Infrastructure.Data;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Implementations.Services
{
    public class UserAuthentication:IUserAuthentication
    {
        private readonly ApplicationDbContext context;
        private readonly JwtOptions jwtOptions;

        public UserAuthentication(ApplicationDbContext context , JwtOptions jwtOptions)
        {
            this.context = context;
            this.jwtOptions = jwtOptions;
        }

        string GenerateToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
           };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.ApiKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issure,
                audience: jwtOptions.Audiance,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtOptions.Time),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public GeneralResponse<string> Register(UserRegisterDto user)
        {
            if (user != null)
            {
                User userToSave = new User()
                {
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password,
                };

                if (context.Users.Any(u => u.Email == user.Email))
                {
                    return new GeneralResponse<string>
                    {
                        Data = "Email already exists",
                        IsSuccess = false
                    };
                }

                context.Users.Add(userToSave);
                context.SaveChanges();
                return new GeneralResponse<string>()
                {
                    Data = "User Added Successfully"
                    ,
                    IsSuccess = true
                };
            }

            return new GeneralResponse<string>()
            {
                Data = "invalid Data"
                    ,
                IsSuccess = false
            };
        }
        public GeneralResponse<string> Login(UserForLoginDto user)
        {
            if (user !=null)
            {
                
                User userFromDb = context.Users.FirstOrDefault(u => u.Name == user.Username && u.Password == user.Password);
                if (userFromDb == null)
                {
                    return new GeneralResponse<string>()
                    {
                        Data = "Invalid Data"
                    ,
                        IsSuccess = false
                    };
                }


                string token = GenerateToken(userFromDb);

                return new GeneralResponse<string>()
                {
                    Data = token
                    ,
                    IsSuccess = true
                };

            }

            return new GeneralResponse<string>()
            {
                Data = "Invalid Data"
                    ,
                IsSuccess = false
            };
        }


    }
}
