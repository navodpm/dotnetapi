using CommonService.DataAccessLayer.Entities;

namespace CommonService.BusinessLogicLayer.Service.Interfaces
{
    public interface IUserService
    {
        Task<Role> CreateRoleAsync(Role role);
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role?> GetRolesByIdAsync(int id);
        Task<bool> DeleteRole(int id);
        Task<User> GetUserByUserNamePassword();
        Task<User> ValidateUser(User user);
        Task<Role> ChangePassword(User user);
    }
}
