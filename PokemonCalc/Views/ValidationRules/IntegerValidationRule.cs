using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PokemonCalc.Views.ValidationRules
{
    public class IntegerValidationRule: ValidationRule
    {
        public IntegerValidationRule()
        {
            MinValue = int.MinValue;
            MaxValue = int.MaxValue;
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || !(value is string))
                return new ValidationResult(false, "不正な値です。");
            int i;
            if (!int.TryParse(value as string, out i))
                return new ValidationResult(false, "数値を入力してください。");
            if (i < MinValue)
                return new ValidationResult(false, "値は " + MinValue + " 以上でなければなりません。");
            if (i > MaxValue)
                return new ValidationResult(false, "値は " + MaxValue + " 以下でなければなりません。");
            return ValidationResult.ValidResult;
        }
        
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
