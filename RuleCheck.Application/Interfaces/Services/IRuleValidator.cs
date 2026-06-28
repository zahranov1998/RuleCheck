using RuleCheck.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuleCheck.Domain.Entities;

namespace RuleCheck.Application.Interfaces.Services;

public interface IRuleValidator
{
    RuleType RuleType { get; }

    bool Validate(Rule rule, object? value);
}