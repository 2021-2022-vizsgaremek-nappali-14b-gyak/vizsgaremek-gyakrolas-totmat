using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;

namespace Vizsgaremek.Validation
{
    public class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string)
            {
                string nameToCheck = (string)value;
                if (nameToCheck.Length > 0)
                {
                    char firstLatter = nameToCheck.ElementAt(0);
                    if (char.IsLower(firstLatter))
                        return new ValidationResult(false, "A név első betűje nagybetű kell legyen!");
                    else
                    {
                        if (nameToCheck.Length > 3)
                        {
                            foreach (char c in nameToCheck.Substring(1))
                            {
                                if (char.IsUpper(c))
                                    return new ValidationResult(false, "Az első nagybetű után csak kisbetűk lehetnek a névben!");
                            }
                            return new ValidationResult(true, "A név megfelel a szabályoknak!");
                        }
                        else
                        {
                            return new ValidationResult(false, "A név legalább 4 betűvől kell hogy álljon!");
                        }
                    }
                }
                else
                {
                    return new ValidationResult(false, "A név nem lehet üres string");
                }
            }
            else
            {
                return new ValidationResult(true, "");
            }
        }
    }
}
