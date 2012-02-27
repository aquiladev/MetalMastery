using System.ComponentModel.DataAnnotations;
using MetalMastery.Web.App_LocalResources;

namespace MetalMastery.Web.Models
{
    [MetadataType(typeof(LogOnModelMetadata))]
    public class LogOnModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class LogOnModelMetadata
    {
        [Required]
        //TODO: Создать валидатор для email 
        //[EmailAddress(ErrorMessage = "E-mail adresse er ikke gyldig")]
        [StringLength(256, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "EmailLength")]
        public string Email { get; set; }

        [Required]
        //TODO: Вставить регулярку на разрешенный символы [0-9a-zA-Z+-!]
        [DataType(DataType.Password)]
        [StringLength(32, MinimumLength = 5, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "PasswordLength")]
        public string Password { get; set; }
    }
}