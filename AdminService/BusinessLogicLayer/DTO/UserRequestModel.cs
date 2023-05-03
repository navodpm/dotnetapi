﻿using System.ComponentModel.DataAnnotations;

namespace AdminService.BusinessLogicLayer.DTO
{
    public class NewUserRequestModel : UserRequestModel
    {

        [Required]
        [StringLength(150, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;


    }

    public class UserRequestModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string UserName { get; set; } = null!;

        [Required]
        public string EmailId { get; set; } = null!;
    }
}
