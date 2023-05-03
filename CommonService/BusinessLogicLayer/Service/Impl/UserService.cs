using CommonService.BusinessLogicLayer.Service.Interfaces;
using CommonService.DataAccessLayer.Entities;
using CommonService.DataAccessLayer.Repository.Interfaces;

namespace CommonService.BusinessLogicLayer.Service.Impl
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

        public Task<User> GetUserByUserNamePassword()
        {
            throw new NotImplementedException();
        }

        public Task<User> ValidateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Role> ChangePassword(User user)
        {
            throw new NotImplementedException();
        }
    }
}
