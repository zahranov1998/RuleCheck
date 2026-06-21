using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Application.Dtos.Validate
{
    public class ValidateResponse
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
