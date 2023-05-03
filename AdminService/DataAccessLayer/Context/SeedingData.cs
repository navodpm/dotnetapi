using AdminService.DataAccessLayer.Entities;

namespace AdminService.DataAccessLayer.Context
{
    public class SeedingData
    {
        public static List<Role> GetRoles()
        {
            return new List<Role>
             {
                 new Role{ Id =1 , Description = "Admin", IsActive = true, CreatedOn = DateTime.UtcNow},
                 new Role{ Id =2 , Description = "Normal", IsActive=true, CreatedOn = DateTime.UtcNow},
             };
        }

        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User{ Id =1 , CreatedOn = DateTime.UtcNow, EmailId = "admin@outlook.com", IsActive = true, Name = "Admin", RoleId =1, UserName = "admin", Password = EasyEncryption.MD5.ComputeMD5Hash("12345678")},
            };
        }
    }
}
