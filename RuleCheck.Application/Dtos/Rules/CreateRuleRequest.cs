using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Application.Dtos.Rules;

public class CreateRuleRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
}