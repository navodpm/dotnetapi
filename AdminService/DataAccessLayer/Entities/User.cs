using System.Data;
using AdminService.DataAccessLayer.Entities.Base;

namespace AdminService.DataAccessLayer.Entities
{
    public partial class User : EntityBase, IStatusEntity
    {

        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public int RoleId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Role Role { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}
