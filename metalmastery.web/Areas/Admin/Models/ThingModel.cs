using System;
using System.ComponentModel.DataAnnotations;
using MetalMastery.Core.Domain;

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
    }
}