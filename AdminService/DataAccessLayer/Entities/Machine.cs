using AdminService.DataAccessLayer.Entities.Base;

namespace AdminService.DataAccessLayer.Entities
{
    public partial class Machine : EntityBase, IStatusEntity
    {
        public string Name { get; set; } = null!;
        public Guid MachineId { get; set; } = new Guid();
        public int MachineTypeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
    }

    public partial class MachineType : EntityBase, IStatusEntity
    {
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
