using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Auth;
using Application.GeneralResponses;

namespace Application.Interfaces.Services
{
    public interface IUserAuthentication
    {
        public GeneralResponse<string> Login(UserForLoginDto user);
        public GeneralResponse<string> Register(UserRegisterDto user);
    }
}
