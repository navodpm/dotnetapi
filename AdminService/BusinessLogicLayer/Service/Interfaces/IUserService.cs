using AdminService.BusinessLogicLayer.DTO;
using AdminService.DataAccessLayer.Entities;

namespace AdminService.BusinessLogicLayer.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<Role> CreateRoleAsync(Role role);
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role?> GetRolesByIdAsync(int id);
        Task<bool> DeleteRole(int id);
        Task<User?> GetUserByUserNamePassword(User user);
        Task<bool> DeleteAsync(int id);
        Task<User?> GetUserByIdAsync(int id);
        Task<int> SaveAsync();
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersWithRoles();
    }
}
