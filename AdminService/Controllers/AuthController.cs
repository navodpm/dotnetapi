using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using AdminService.BusinessLogicLayer.DTO;
using AdminService.Core;
using AdminService.BusinessLogicLayer.Service.Interfaces;
using AdminService.DataAccessLayer.Entities;

namespace AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiBaseController
    {
        private readonly IServiceWrapper service;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public AuthController(IServiceWrapper service, IConfiguration configuration, IMapper mapper)
        {
            this.service = service;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel loginModel)
        {
            var userModel = mapper.Map<User>(loginModel);
            var user = await this.service.UserService.GetUserByUserNamePassword(userModel);

            if (user is null)
                return Unauthorized("Invalid UserName or Password!");

            var token = JWT.GenerateToken(new Dictionary<string, string> {
                { ClaimTypes.Role, user.Role.Description  },
                { "roleId", user.Role.Id.ToString()  },
                //{ JwtClaimTypes.PreferredUserName, user.Name },
                { "userName", user.UserName },
                { JwtClaimTypes.Id, user.Id.ToString() },
                { JwtClaimTypes.Email, user.EmailId}
            }, configuration["JWT:Key"]);

            var userResp = mapper.Map<UserResponseModel>(user);
            return CreateSuccessResponse(new { AuthToken = token, UserData = userResp });
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequestModel changePasswordModel)
        {
            var userModel = mapper.Map<User>(changePasswordModel);
            //userModel.Password = changePasswordModel.NewPassword;
            var user = await this.service.UserService.GetUserByUserNamePassword(userModel);

            if (user is null)
                return Unauthorized("Invalid UserName or Password!");

            if (!changePasswordModel.NewPassword.Equals(changePasswordModel.ConfirmPassword))
                return CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, new List<string> { $"Password and Confirm Password Mismatch" });

            var hashedPassNew = EasyEncryption.MD5.ComputeMD5Hash(changePasswordModel.NewPassword);
            user.Password = hashedPassNew;

            var rowsAffected = await this.service.UserService.SaveAsync();
            if (rowsAffected > 0)
                return CreateSuccessResponse($"User: {user.UserName}, Updated successfully!");
            return CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, new List<string> { $"User: {user.UserName}, Not Updated!" });
        }
    }

}
