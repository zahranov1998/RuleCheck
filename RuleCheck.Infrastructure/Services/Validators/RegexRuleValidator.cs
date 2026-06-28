using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RuleCheck.Application.Interfaces.Services;
using RuleCheck.Domain.Entities;
using RuleCheck.Domain.Enums;

namespace RuleCheck.Infrastructure.Services.Validators;

public class RegexRuleValidator : IRuleValidator
{
    public RuleType RuleType => RuleType.Regex;
    public bool Validate(Rule rule, object? value)
    {
        if (value == null)
            return false;

        if (string.IsNullOrWhiteSpace(rule.Pattern))
            return false;

        return Regex.IsMatch(
            value.ToString()!,
            rule.Pattern);
    }
}