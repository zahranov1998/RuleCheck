using RuleCheck.Application.Dtos.Validate;
using RuleCheck.Application.Interfaces.Persistence;
using RuleCheck.Application.Interfaces.Services;
using RuleCheck.Domain.Enums;
using System.Text.RegularExpressions;

namespace RuleCheck.Infrastructure.Services;

public class RuleEngine : IRuleEngine
{
    private readonly IRuleRepository _ruleRepository;

    public RuleEngine(IRuleRepository ruleRepository)
    {
        _ruleRepository = ruleRepository;
    }

    public async Task<ValidateResponse> ValidateAsync(ValidateRequest request)
    {
        var rules = await _ruleRepository.GetAllAsync();

        var response = new ValidateResponse();

        foreach (var rule in rules.Where(r => r.IsActive))
        {
            request.Data.TryGetValue(rule.FieldName, out var value);

            switch (rule.RuleType)
            {
                case RuleType.Required:
                    if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        response.Errors.Add(rule.ErrorMessage);
                    }
                    break;

                case RuleType.Regex:
                    if (value != null &&
                        !string.IsNullOrWhiteSpace(rule.Pattern))
                    {
                        var isMatch = Regex.IsMatch(
                            value.ToString()!,
                            rule.Pattern);

                        if (!isMatch)
                        {
                            response.Errors.Add(rule.ErrorMessage);
                        }
                    }
                    break;

                case RuleType.Range:
                    if (value != null &&
                        int.TryParse(value.ToString(), out var intValue))
                    {
                        if (rule.MinValue.HasValue &&
                            intValue < rule.MinValue.Value)
                        {
                            response.Errors.Add(rule.ErrorMessage);
                        }

                        if (rule.MaxValue.HasValue &&
                            intValue > rule.MaxValue.Value)
                        {
                            response.Errors.Add(rule.ErrorMessage);
                        }
                    }
                    break;
            }
        }

        response.IsValid = !response.Errors.Any();

        return response;
    }
}