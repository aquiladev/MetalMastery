using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MetalMastery.Web.App_LocalResources;

namespace MetalMastery.Web.Models
{
    public class RegistrateModel : LogOnModel
    {
        [Required]
        [Compare("Password", ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "ConfirmPasswordErrorMessage")]
        public string ConfirmPassword { get; set; }
    }
}