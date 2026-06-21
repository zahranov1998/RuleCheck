using RuleCheck.Application.Dtos.Validate;
using RuleCheck.Application.Interfaces.Persistence;
using RuleCheck.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (!request.Data.ContainsKey(rule.Name))
            {
                response.Errors.Add($"{rule.Name} is required");
                response.IsValid = false;
            }
        }

        if (!response.Errors.Any())
            response.IsValid = true;

        return response;
    }
}