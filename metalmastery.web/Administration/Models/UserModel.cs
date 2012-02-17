using System.ComponentModel.DataAnnotations;
using MetalMastery.Core.Domain;

namespace MetalMastery.Admin.Models
{
    [MetadataType(typeof(UserModelMetadata))]
    public class UserModel : User
    {
    }

    public class UserModelMetadata
    {
    }
}