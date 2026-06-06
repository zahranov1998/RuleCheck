using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Application.Dtos;

public class UpdateRuleRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}