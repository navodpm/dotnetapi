using System.ComponentModel.DataAnnotations;

namespace AdminService.BusinessLogicLayer.DTO
{
    public class MachineRequestModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        public int? MachineTypeId { get; set; } = null!;
    }

    public class MachineResponseModel
    {
        public string Name { get; set; } = null!;
        public int? TypeId { get; set; } = null!;
        public string QRCodeTextBase64 { get; set; } = null!;
    }
}
