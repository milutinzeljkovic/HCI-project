using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectHCI
{
    class ValidationEmptyTextBox : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var s = value as string;
            if (s == "")
            {

                return new ValidationResult(false, "Required field");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }

    }
}
