using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace api.Attributes
{
    public class MongoPreventAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //TODO 測試相同寫法，為何 RegularExpressionAttribute 驗證無效
            return Regex.IsMatch( (string)value, @"^[^$]" ) ;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }
    }
}