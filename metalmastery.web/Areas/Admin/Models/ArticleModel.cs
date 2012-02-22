using System;
using System.ComponentModel.DataAnnotations;
using MetalMastery.Core.Domain;

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
    }
}