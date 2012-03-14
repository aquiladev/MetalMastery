using System;
using System.Globalization;
using AutoMapper;

namespace MetalMastery.Web.Framework.AutoMapper
{
    public class StrToDateConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(ResolutionContext context)
        {
            DateTime dateTime;

            if (context.SourceValue == null
                || string.IsNullOrEmpty(context.SourceValue.ToString()))
            {
                return DateTime.Now;
            }

            DateTime.TryParse(
                context.SourceValue.ToString(),
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateTime);

            return dateTime;
        }
    }
}
