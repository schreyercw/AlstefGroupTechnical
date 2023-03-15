using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlstefGroupTechnical.BusinessRules.Models
{
    public class NumberValidationResult
    {
        public bool IsValid => ErrorMessage is not null;
        public int? ValidatedNumber { get; set; }
        public string? ErrorMessage { get; set; }
        public NumberValidationResultType ResultType { get; set; }
    }
}