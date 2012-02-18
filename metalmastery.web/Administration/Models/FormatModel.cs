using System;
using System.ComponentModel.DataAnnotations;
using MetalMastery.Core.Domain;

namespace MetalMastery.Admin.Models
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
    }
}