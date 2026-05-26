using Microsoft.EntityFrameworkCore;
using RuleCheck.Application.Dtos;
using RuleCheck.Application.Interfaces;
using RuleCheck.Domain.Entities;
using RuleCheck.Infrastructure.Persistence;

namespace RuleCheck.Infrastructure.Services;

public class RuleService : IRuleService
{
    private readonly RuleCheckDbContext _context;

    public RuleService(RuleCheckDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RuleDto>> GetAllAsync()
    {
        var rules = await _context.Rules.ToListAsync();

        return rules.Select(r => new RuleDto
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description,
            IsActive = r.IsActive
        });
    }

    public async Task<RuleDto?> GetByIdAsync(int id)
    {
        var rule = await _context.Rules.FindAsync(id);

        if (rule == null)
            return null;

        return new RuleDto
        {
            Id = rule.Id,
            Name = rule.Name,
            Description = rule.Description,
            IsActive = rule.IsActive
        };
    }

    public async Task<RuleDto> CreateAsync(RuleDto dto)
    {
        var rule = new Rule
        {
            Name = dto.Name,
            Description = dto.Description,
            IsActive = dto.IsActive
        };

        _context.Rules.Add(rule);
        await _context.SaveChangesAsync();

        dto.Id = rule.Id;
        return dto;
    }

    public async Task<RuleDto?> UpdateAsync(int id, RuleDto dto)
    {
        var rule = await _context.Rules.FindAsync(id);

        if (rule == null)
            return null;

        rule.Name = dto.Name;
        rule.Description = dto.Description;
        rule.IsActive = dto.IsActive;

        await _context.SaveChangesAsync();

        return new RuleDto
        {
            Id = rule.Id,
            Name = rule.Name,
            Description = rule.Description,
            IsActive = rule.IsActive
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var rule = await _context.Rules.FindAsync(id);

        if (rule == null)
            return false;

        _context.Rules.Remove(rule);
        await _context.SaveChangesAsync();

        return true;
    }
}
