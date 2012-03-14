using System;
using System.ComponentModel.DataAnnotations;
using MetalMastery.Core.Domain;
using MetalMastery.Web.App_LocalResources;

namespace MetalMastery.Web.Areas.Admin.Models
{
    [MetadataType(typeof(TagModelMetadata))]
    public class TagModel : Tag
    {
        public TagModel()
        {
            if (Id.Equals(default(Guid)))
            {
                Id = Guid.NewGuid();
            }
        }
    }

    public class TagModelMetadata
    {
        [Required]
        [StringLength(32, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldLength")]
        public string Name { get; set; }
    }
}