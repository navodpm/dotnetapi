using WebAPI.DataAccessLayer.Entities;

namespace WebAPI.DataAccessLayer.Context
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
                new User{ Id =1 , CreatedOn = DateTime.UtcNow, EmailId = "mak.thevar@outlook.com", IsActive = true, Name = "mak thevar", RoleId =1, Username = "mak-thevar", Password = EasyEncryption.MD5.ComputeMD5Hash("12345678")},
            };
        }
    }
}
