using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace MetalMastery.Web.Framework.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class UrlAttribute : ValidationAttribute, IClientValidatable
    {
        private const string UrlRegExp = @"^(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*$";
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            return Regex.IsMatch(value.ToString(), UrlRegExp);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(GetErrorMessage(), name);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
                             {
                                 ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                                 ValidationType = "url"
                             };
        }

        public string GetErrorMessage()
        {
            PropertyInfo prop = ErrorMessageResourceType.GetProperty(ErrorMessageResourceName);
            return prop.GetValue(null, null).ToString();
        }
    }
}
