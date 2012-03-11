using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MetalMastery.Web.App_LocalResources;

namespace MetalMastery.Web.Areas.Admin.Models
{
    [MetadataType(typeof(ArticleModelMetadata))]
    public class ArticleModel
    {
        public ArticleModel()
        {
            if (Id.Equals(default(Guid)))
            {
                Id = Guid.NewGuid();
            }
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string CreateDate { get; set; }

        public Guid OwnerId { get; set; }

        public string OwnerName { get; set; }

        public bool IsPublished { get; set; }

    }

    public class ArticleModelMetadata
    {
        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldLength")]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(2000, ErrorMessageResourceType = typeof(MmResources), ErrorMessageResourceName = "FieldLength")]
        public string Text { get; set; }
    }
}