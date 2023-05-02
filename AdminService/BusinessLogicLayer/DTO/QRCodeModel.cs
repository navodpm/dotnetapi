using System.ComponentModel.DataAnnotations;

namespace AdminService.BusinessLogicLayer.DTO
{
    public class QRCodeModel
    {
        [Required]
        [StringLength(150, MinimumLength = 6)]
        public string QRCodeText { get; set; } = null!;

        public string QRCodeTextBase64 { get; set; } = null!;
    }
}
