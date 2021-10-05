using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AspNetCoreMvcWithLightVue.Infra
{
    public class DecimalRangeAttribute : ValidationAttribute
    {
        public DecimalRangeAttribute(string min, string max)
        {
            Decimal.TryParse(min, out _min);
            Decimal.TryParse(max, out _max);
        }

        private readonly Decimal _min;
        private readonly Decimal _max;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var inputDate = value as decimal?;
            if (inputDate == null)
            {
                // Reqiured 的判斷不從這邊處理
                return ValidationResult.Success;
            }

            if (inputDate.Value > _max
             || inputDate.Value < _min)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture,
                                 ErrorMessageString,
                                 new object[3]
                                 {
                                     (object)name,
                                     (object)_max,
                                     (object)_min,
                                 });
        }
    }
}
