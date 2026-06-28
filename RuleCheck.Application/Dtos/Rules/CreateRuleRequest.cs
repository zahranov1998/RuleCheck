using RuleCheck.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Application.Dtos.Rules;

public class CreateRuleRequest
{
    public string FieldName { get; set; } = string.Empty;

    public RuleType RuleType { get; set; }

    public string? Pattern { get; set; }

    public int? MinValue { get; set; }

    public int? MaxValue { get; set; }

    public string ErrorMessage { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}