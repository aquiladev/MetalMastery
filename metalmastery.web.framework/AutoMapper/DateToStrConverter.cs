using System;
using System.Globalization;
using AutoMapper;

namespace MetalMastery.Web.Framework.AutoMapper
{
    public class DateToStrConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(ResolutionContext context)
        {
            return ((DateTime)context.SourceValue).ToString(CultureInfo.InvariantCulture);
        }
    }
}
