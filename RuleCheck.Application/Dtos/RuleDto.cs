using RuleCheck.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Application.Dtos;

public class RuleDto
{
    public int Id { get; set; }
    public string FieldName { get; set; }
    public RuleType RuleType { get; set; }
    public string? Pattern { get; set; }
    public int? MinValue { get; set; }
    public int? MaxValue { get; set; }
    public string ErrorMessage { get; set; }
}