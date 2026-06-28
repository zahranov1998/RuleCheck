using RuleCheck.Domain.Enums;

namespace RuleCheck.Application.Dtos.Rules;

public class RuleResponse
{
    public int Id { get; set; }

    public string FieldName { get; set; } = string.Empty;

    public RuleType RuleType { get; set; }

    public string? Pattern { get; set; }

    public int? MinValue { get; set; }

    public int? MaxValue { get; set; }

    public string ErrorMessage { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}