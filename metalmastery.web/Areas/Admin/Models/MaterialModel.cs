using System;
using System.ComponentModel.DataAnnotations;
using MetalMastery.Core.Domain;
using MetalMastery.Web.App_LocalResources;

namespace MetalMastery.Web.Areas.Admin.Models
{
    [MetadataType(typeof(MaterialModelMetadata))]
    public class MaterialModel : Material
    {
        public MaterialModel()
        {
            if (Id.Equals(default(Guid)))
            {
                Id = Guid.NewGuid();
            }
        }
    }

    public class MaterialModelMetadata
    {
        [Required]
        [StringLength(32, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldLength")]
        public string Name { get; set; }
    }
}