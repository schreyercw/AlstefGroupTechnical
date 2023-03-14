using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlstefGroupTechnical.BusinessRules.Enums
{
    public enum NumberValidationResult
    {
        ValidNumber,
        EmptyOrNullString,
        ContainsUnknownCharacters,
        OutOfRange
    }
}
