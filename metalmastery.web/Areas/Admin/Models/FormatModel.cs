using System;
using System.ComponentModel.DataAnnotations;
using MetalMastery.Core.Domain;
using MetalMastery.Web.App_LocalResources;

namespace MetalMastery.Web.Areas.Admin.Models
{
    [MetadataType(typeof(FormatModelMetadata))]
    public class FormatModel : Format
    {
        public FormatModel()
        {
            if (Id.Equals(default(Guid)))
            {
                Id = Guid.NewGuid();
            }
        }
    }

    public class FormatModelMetadata
    {
        [Required]
        [StringLength(32, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldLength")]
        public string Name { get; set; }
    }
}