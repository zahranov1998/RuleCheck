using Microsoft.EntityFrameworkCore;
using RuleCheck.Application.Dtos;
using RuleCheck.Application.Interfaces.Persistence;
using RuleCheck.Application.Interfaces.Services;
using RuleCheck.Domain.Entities;
using RuleCheck.Infrastructure.Persistence;

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
            Name = r.Name,
            Description = r.Description,
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
            Name = rule.Name,
            Description = rule.Description,
            IsActive = rule.IsActive
        };
    }

    public async Task<RuleResponse> CreateAsync(CreateRuleRequest request)
    {
        var rule = new Rule
        {
            Name = request.Name,
            Description = request.Description,
            IsActive = true // default
        };

         await _repository.AddAsync(rule);

        return new RuleResponse
        {
            Id = rule.Id,
            Name = rule.Name,
            Description = rule.Description,
            IsActive = rule.IsActive
        };
    }

    public async Task<RuleResponse?> UpdateAsync(int id, UpdateRuleRequest request)
    {
        var rule = await _repository.GetByIdAsync(id);

        if (rule == null)
            return null;

        rule.Name = request.Name;
        rule.Description = request.Description;
        rule.IsActive = request.IsActive;

        await _repository.UpdateAsync(rule);

        return new RuleResponse
        {
            Id = rule.Id,
            Name = rule.Name,
            Description = rule.Description,
            IsActive = rule.IsActive
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

