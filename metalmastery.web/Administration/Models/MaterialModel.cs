using System;
using System.ComponentModel.DataAnnotations;
using MetalMastery.Core.Domain;

namespace MetalMastery.Admin.Models
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
    }
}