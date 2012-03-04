using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MetalMastery.Web.App_LocalResources;

namespace MetalMastery.Web.Models
{
    public class RegistrateModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(256, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "EmailLength")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "EmailIncorrect")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(32, MinimumLength = 5, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "PasswordLength")]
        [RegularExpression(".*[!@#$%^&+=].*", ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "PasswordIncorrect")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "ConfirmPasswordErrorMessage")]
        public string ConfirmPassword { get; set; }
    }
}