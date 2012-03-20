using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MetalMastery.Core.Mvc
{
    public class ClientModelValidatorsProvider
    {
        private const string DataVal = "data-val";
        private const string Separator = "-";

        public static Dictionary<string, object> GetValidators(Type model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            var modelValidators = new Dictionary<string, object>();

            var metaDatas = ModelMetadataProviders.Current.GetMetadataForProperties(null, model);
            foreach (var modelMetadata in metaDatas)
            {
                var validators = GetValidatorsFromMetadate(modelMetadata).ToList();

                if (validators.Count > 0)
                {
                    validators.Add(new
                                       {
                                           Value = DataVal,
                                           Text = true
                                       });

                    modelValidators.Add(
                        modelMetadata.PropertyName,
                        validators);
                }
            }
            return modelValidators;
        }

        public static Dictionary<string, object> GetValidatorsForProperty(Type model, String propertyName)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (propertyName == null)
                throw new ArgumentNullException("propertyName");

            var modelValidators = new Dictionary<string, object>();

            var metaData = ModelMetadataProviders.Current.GetMetadataForProperty(null, model, propertyName);

            var validators = GetValidatorsFromMetadate(metaData).ToList();

            if (validators.Count > 0)
            {
                validators.Add(new
                                   {
                                       Value = DataVal,
                                       Text = true
                                   });

                modelValidators.Add(
                    metaData.PropertyName,
                    validators);
            }

            return modelValidators;
        }

        #region

        private static IEnumerable<object> GetValidatorsFromMetadate(ModelMetadata metadata)
        {
            if (metadata == null)
                throw new ArgumentNullException("metadata");

            var validators = new List<object>();

            foreach (var validator in ModelValidatorProviders.Providers.GetValidators(metadata, new ControllerContext()))
            {
                validators.AddRange(GetPropertyValidators(validator));
            }

            return validators;
        }

        private static IEnumerable<object> GetPropertyValidators(ModelValidator validator)
        {
            if (validator == null)
                throw new ArgumentNullException("validator");

            var rules = new List<object>();

            foreach (var rule in validator.GetClientValidationRules())
            {
                rules.Add(GetClientValidationRule(rule));
                rules.AddRange(GetClientValidationParameters(rule));
            }

            return rules;
        }

        private static object GetClientValidationRule(ModelClientValidationRule rule)
        {
            if (rule == null)
                throw new ArgumentNullException("rule");

            return new
            {
                Value = string.Concat(
                    DataVal,
                    Separator,
                    rule.ValidationType),
                Text = rule.ErrorMessage
            };
        }

        private static IEnumerable<object> GetClientValidationParameters(ModelClientValidationRule rule)
        {
            if (rule == null)
                throw new ArgumentNullException("rule");

            foreach (var validParams in rule.ValidationParameters)
            {
                yield return new
                {
                    Value = string.Concat(
                        DataVal,
                        Separator,
                        rule.ValidationType,
                        Separator,
                        validParams.Key),
                    Text = validParams.Value
                };
            }
        }

        #endregion
    }
    
}
