using RuleCheck.Application.Dtos.Validate;
using RuleCheck.Application.Interfaces.Persistence;
using RuleCheck.Application.Interfaces.Services;
using RuleCheck.Domain.Enums;
using System.Text.RegularExpressions;

namespace RuleCheck.Infrastructure.Services;

public class RuleEngine : IRuleEngine
{
    private readonly IRuleRepository _ruleRepository;
    private readonly IEnumerable<IRuleValidator> _validators;

    public RuleEngine(
        IRuleRepository ruleRepository,
        IEnumerable<IRuleValidator> validators)
    {
        _ruleRepository = ruleRepository;
        _validators = validators;
    }

    public async Task<ValidateResponse> ValidateAsync(
        ValidateRequest request)
    {
        var rules = await _ruleRepository.GetAllAsync();

        var response = new ValidateResponse();

        foreach (var rule in rules.Where(r => r.IsActive))
        {
            request.Data.TryGetValue(
                rule.FieldName,
                out var value);

            var validator = _validators.SingleOrDefault(
                v => v.RuleType == rule.RuleType);

            if (validator == null)
            {
                throw new InvalidOperationException(
                    $"No validator found for rule type {rule.RuleType}");
            }

            var isValid = validator.Validate(rule, value);

            if (!isValid)
            {
                response.Errors.Add(rule.ErrorMessage);
            }
        }

        response.IsValid = !response.Errors.Any();

        return response;
    }
}