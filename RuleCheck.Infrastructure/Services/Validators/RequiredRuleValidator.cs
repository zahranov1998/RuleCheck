using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuleCheck.Application.Interfaces.Services;
using RuleCheck.Domain.Entities;
using RuleCheck.Domain.Enums;

namespace RuleCheck.Infrastructure.Services.Validators;

public class RequiredRuleValidator : IRuleValidator
{
    public RuleType RuleType => RuleType.Required;

    public bool Validate(Rule rule, object? value)
    {
        return value != null &&
               !string.IsNullOrWhiteSpace(value.ToString());
    }
}