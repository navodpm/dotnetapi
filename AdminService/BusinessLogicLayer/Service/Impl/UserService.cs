using AdminService.BusinessLogicLayer.DTO;
using AdminService.BusinessLogicLayer.Service.Interfaces;
using AdminService.DataAccessLayer.Entities;
using AdminService.DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdminService.BusinessLogicLayer.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public UserService(IRepositoryWrapper _repositoryWrapper)
        {
            repositoryWrapper = _repositoryWrapper;
        }

        public Task<Role> CreateRoleAsync(Role role)
        {
            return repositoryWrapper.UserRepository.CreateRoleAsync(role);
        }

        public Task<bool> DeleteRole(int id)
        {
            return repositoryWrapper.UserRepository.DeleteRole(id);
        }

        public Task<IEnumerable<Role>> GetRolesAsync()
        {
            return repositoryWrapper.UserRepository.GetRolesAsync();
        }

        public Task<Role?> GetRolesByIdAsync(int id)
        {
            return repositoryWrapper.UserRepository.GetRolesByIdAsync(id);
        }

        public Task<int> SaveAsync()
        {
            return repositoryWrapper.SaveAsync();
        }

        public async Task<User?> GetUserByUserNamePassword(User user)
        {
            var hashedPass = EasyEncryption.MD5.ComputeMD5Hash(user.Password);
            var userDetail = (await repositoryWrapper.UserRepository.GetQueryable().Include(o => o.Role).SingleOrDefaultAsync(x => x.UserName == user.UserName && x.Password == hashedPass));
            return userDetail;
        }

        public Task<bool> DeleteAsync(int id)
        {
            return repositoryWrapper.UserRepository.DeleteAsync(id);
        }

        public Task<User?> GetUserByIdAsync(int id)
        {
            return repositoryWrapper.UserRepository.GetByIdAsync(id);
        }

        public Task<User> AddUser(User user)
        {
            return repositoryWrapper.UserRepository.AddAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await repositoryWrapper.UserRepository.GetAllAsync();
        }

        public Task<IEnumerable<User>> GetAllUsersWithRoles()
        {
            return repositoryWrapper.UserRepository.GetAllUsersWithRoles();
        }
    }
}
