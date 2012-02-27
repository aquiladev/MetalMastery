using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MetalMastery.Web.App_LocalResources;

namespace MetalMastery.Web.Models
{
    public class RegistrateModel
    {
        [Required]
        [StringLength(256, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "EmailLength")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(32, MinimumLength = 5, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "PasswordLength")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "ConfirmPasswordErrorMessage")]
        public string ConfirmPassword { get; set; }
    }
}