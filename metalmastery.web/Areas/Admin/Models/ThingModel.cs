using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MetalMastery.Core.Domain;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Framework.Validation;

namespace MetalMastery.Web.Areas.Admin.Models
{
    [MetadataType(typeof(ThingModelMetadata))]
    public class ThingModel : Thing
    {
        public ThingModel()
        {
            if (Id.Equals(default(Guid)))
            {
                Id = Guid.NewGuid();
            }
        }
    }

    public class ThingModelMetadata
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 1, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldLength")]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(5000, MinimumLength = 1, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldLength")]
        public string Description { get; set; }

        public bool ShowOnHome { get; set; }

        public bool ShowForAll { get; set; }

        [Range(0, 5, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldRangeRestrict")]
        public int Rating { get; set; }

        [StringLength(256, MinimumLength = 1, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldLength")]
        public string Image1 { get; set; }

        [StringLength(256, MinimumLength = 1, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldLength")]
        public string Image2 { get; set; }

        [StringLength(2000, MinimumLength = 1, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldLength")]
        public string Comment { get; set; }

        [Required]
        [Url(ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "UrlIncorrect")]
        [StringLength(256, MinimumLength = 1, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldLength")]
        public string ImageRes { get; set; }
    }
}