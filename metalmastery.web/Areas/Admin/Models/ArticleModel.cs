using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MetalMastery.Core.Domain;
using MetalMastery.Web.App_LocalResources;

namespace MetalMastery.Web.Areas.Admin.Models
{
    [MetadataType(typeof(ArticleModelMetadata))]
    public class ArticleModel : Article
    {
        public ArticleModel()
        {
            if (Id.Equals(default(Guid)))
            {
                Id = Guid.NewGuid();
            }
        }
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