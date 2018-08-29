using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MessageApp.Common
{
    public class RecipientsNotEmptyAttribute : ValidationAttribute
    {
        public RecipientsNotEmptyAttribute()
        {
            ErrorMessage = "One or more recipients are empty.";
        }
        public override bool IsValid(object value)
        {
            return !(value as IEnumerable<string>)?.Any(x => string.IsNullOrEmpty(x)) ?? true;
        }
    }
}
