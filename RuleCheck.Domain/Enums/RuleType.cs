using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Domain.Enums;

public enum RuleType
{
    Required = 1,
    Regex = 2,
    Range = 3
}