using System.Text;
using AutoMapper;

namespace MetalMastery.Web.Framework.AutoMapper
{
    public class StrToBytesConverter : ITypeConverter<string, byte[]>
    {
        public byte[] Convert(ResolutionContext context)
        {
            return Encoding.ASCII.GetBytes(context.SourceValue.ToString());
        }
    }
}
