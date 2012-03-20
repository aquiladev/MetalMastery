using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Framework.Validation;

namespace MetalMastery.Web.Areas.Admin.Models
{
    [MetadataType(typeof(ThingModelMetadata))]
    public class ThingModel
    {
        public ThingModel()
        {
            if (Id.Equals(default(Guid)))
            {
                Id = Guid.NewGuid();
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool ShowOnHome { get; set; }

        public bool ShowForAll { get; set; }

        public Guid FormatId { get; set; }

        public int Rating { get; set; }

        public int Price { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Comment { get; set; }

        public string ImageRes { get; set; }

        public string CreateDate { get; set; }

        public Guid MaterialId { get; set; }

        public Guid StateId { get; set; }

        public Guid OwnerId { get; set; }

        public string OwnerName { get; set; }
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