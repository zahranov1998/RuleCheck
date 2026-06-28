using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuleCheck.Application.Interfaces.Services;
using RuleCheck.Domain.Entities;
using RuleCheck.Domain.Enums;

namespace RuleCheck.Infrastructure.Services.Validators;

public class RangeRuleValidator: IRuleValidator
{
    public RuleType RuleType => RuleType.Range;
    public bool Validate(Rule rule, object? value)
    {
        if (value == null)
            return false;

        if (!int.TryParse(value.ToString(), out var number))
            return false;

        return number >= rule.MinValue &&
               number <= rule.MaxValue;
    }
}