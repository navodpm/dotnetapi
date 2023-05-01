using System.ComponentModel.DataAnnotations;

namespace AdminService.BusinessLogicLayer.DTO
{

    public class LoginRequestModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = null!;
    }

    public class ChangePasswordRequestModel: LoginRequestModel
    {

        [Required]
        [StringLength(150, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
