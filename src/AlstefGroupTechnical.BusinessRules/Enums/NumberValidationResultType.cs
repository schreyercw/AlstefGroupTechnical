using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlstefGroupTechnical.BusinessRules.Enums
{
    public enum NumberValidationResultType
    {
        ValidNumber,
        EmptyOrNullString,
        ContainsUnknownCharacters,
        OutOfRange,
        NegativeNumber
    }
}
