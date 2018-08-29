using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MessageApp.Common
{
    public class RecipientsRequiredAttribute : ValidationAttribute
    {
        public RecipientsRequiredAttribute()
        {
            ErrorMessage = "At least one recipient is requred.";
        }

        public override bool IsValid(object value)
        {
            return (value as IEnumerable<string>)?.Any() ?? false;
        }
    }
}
