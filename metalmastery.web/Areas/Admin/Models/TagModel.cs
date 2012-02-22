using System;
using System.ComponentModel.DataAnnotations;
using MetalMastery.Core.Domain;

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
    }
}