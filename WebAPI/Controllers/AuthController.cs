using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAPI.BusinessLogicLayer.DTO;
using WebAPI.Core;
using WebAPI.DataAccessLayer.Repository.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiBaseController
    {
        private readonly IRepositoryWrapper repository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public AuthController(IRepositoryWrapper repository, IConfiguration configuration, IMapper mapper)
        {
            this.repository = repository;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel loginModel)
        {
            var hashedPass = EasyEncryption.MD5.ComputeMD5Hash(loginModel.Password);
            var user = await this.repository.UserRepository.GetQueryable().Include(o => o.Role).SingleOrDefaultAsync(x => x.Username == loginModel.UserName && x.Password == hashedPass);

            if (user is null)
                return Unauthorized("Invalid Username or Password!");


            var token = JWT.GenerateToken(new Dictionary<string, string> {
                { ClaimTypes.Role, user.Role.Description  },
                { "roleId", user.Role.Id.ToString()  },
                //{ JwtClaimTypes.PreferredUserName, user.Name },
                { "userName", user.Name },
                { JwtClaimTypes.Id, user.Id.ToString() },
                { JwtClaimTypes.Email, user.EmailId}
            }, configuration["JWT:Key"]);

            var userResp = mapper.Map<UserResponseModel>(user);
            return CreateSuccessResponse(new { AuthToken = token, UserData = userResp });
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequestModel changePasswordModel)
        {
            var hashedPass = EasyEncryption.MD5.ComputeMD5Hash(changePasswordModel.Password);
            var user = await this.repository.UserRepository.GetQueryable().Include(o => o.Role).SingleOrDefaultAsync(x => x.Username == changePasswordModel.UserName && x.Password == hashedPass);

            if (user is null)
                return Unauthorized("Invalid Username or Password!");

            if (!changePasswordModel.NewPassword.Equals(changePasswordModel.ConfirmPassword))
                return CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, new List<string> { $"Password and Confirm Password Mismatch" });

            var hashedPassNew = EasyEncryption.MD5.ComputeMD5Hash(changePasswordModel.NewPassword);
            user.Password = hashedPassNew;

            var rowsAffected = await repository.SaveAsync();
            if (rowsAffected > 0)
                return CreateSuccessResponse($"User: {user.Username}, Updated successfully!");
            return CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, new List<string> { $"User: {user.Username}, Not Updated!" });

            //var userResp = mapper.Map<UserResponseModel>(user);
            //return CreateSuccessResponse(new { UserData = userResp });
        }
    }

}
