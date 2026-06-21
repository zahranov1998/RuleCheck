using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Application.Dtos.Validate;

public class ValidateRequest
{
    public Dictionary<string, object> Data { get; set; } = new();
}