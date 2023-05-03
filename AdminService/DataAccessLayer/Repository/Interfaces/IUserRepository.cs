using AdminService.DataAccessLayer.Entities;

namespace AdminService.DataAccessLayer.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<Role> CreateRoleAsync(Role role);
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role?> GetRolesByIdAsync(int id);
        Task<bool> DeleteRole(int id);
        Task<IEnumerable<User>> GetAllUsersWithRoles();
        Task<IEnumerable<User>> GetAllUsers();
    }
}
