using Microsoft.EntityFrameworkCore;
using RuleCheck.Application.Dtos.Rules;
using RuleCheck.Application.Interfaces.Persistence;
using RuleCheck.Application.Interfaces.Services;
using RuleCheck.Domain.Entities;
using RuleCheck.Infrastructure.Persistence;
using System.Data;
using Rule = RuleCheck.Domain.Entities.Rule;

namespace RuleCheck.Infrastructure.Services;

public class RuleService : IRuleService
{
    private readonly IRuleRepository _repository;
    public RuleService(IRuleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RuleResponse>> GetAllAsync()
    {
        var rules = await _repository.GetAllAsync();

        return rules.Select(r => new RuleResponse
        {
            Id = r.Id,
            FieldName = r.FieldName,
            RuleType = r.RuleType,
            Pattern = r.Pattern,
            MinValue = r.MinValue,
            MaxValue = r.MaxValue,
            ErrorMessage = r.ErrorMessage,
            IsActive = r.IsActive
        });
    }

    public async Task<RuleResponse?> GetByIdAsync(int id)
    {
        var rule = await _repository.GetByIdAsync(id);

        if (rule == null)
            return null;

        return new RuleResponse
        {
            Id = rule.Id,
            FieldName = rule.FieldName,
            RuleType = rule.RuleType,
            Pattern = rule.Pattern,
            MinValue = rule.MinValue,
            MaxValue = rule.MaxValue,
            ErrorMessage = rule.ErrorMessage,
            IsActive = rule.IsActive
        };
    }

    public async Task<RuleResponse> CreateAsync(CreateRuleRequest request)
    {
        var rule = new Rule
        {
            FieldName = request.FieldName,
            RuleType = request.RuleType,
            Pattern = request.Pattern,
            MinValue = request.MinValue,
            MaxValue = request.MaxValue,
            ErrorMessage = request.ErrorMessage,
            IsActive = request.IsActive
        };

        await _repository.AddAsync(rule);

        return new RuleResponse
        {
            Id = rule.Id,
            FieldName = rule.FieldName,
            RuleType = rule.RuleType,
            Pattern = rule.Pattern,
            MinValue = rule.MinValue,
            MaxValue = rule.MaxValue,
            ErrorMessage = rule.ErrorMessage,
            IsActive = rule.IsActive
        };
    }

    public async Task<RuleResponse?> UpdateAsync(int id, UpdateRuleRequest request)
    {
        var rule = await _repository.GetByIdAsync(id);

        if (rule == null)
            return null;

        rule.FieldName = request.FieldName;
        rule.RuleType = request.RuleType;
        rule.Pattern = request.Pattern;
        rule.MinValue = request.MinValue;
        rule.MaxValue = request.MaxValue;
        rule.ErrorMessage = request.ErrorMessage;
        rule.IsActive = request.IsActive;

        await _repository.UpdateAsync(rule);

        return new RuleResponse
        {
            Id = rule.Id,
            FieldName = rule.FieldName,
            RuleType = rule.RuleType,
            Pattern = rule.Pattern,
            MinValue = rule.MinValue,
            MaxValue = rule.MaxValue,
            ErrorMessage = rule.ErrorMessage,
            IsActive = rule.IsActive,
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var rule = await _repository.GetByIdAsync(id);

        if (rule == null)
            return false;

        await _repository.DeleteAsync(rule);

        return true;
    }
}

