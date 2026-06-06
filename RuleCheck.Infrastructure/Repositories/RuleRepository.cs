using RuleCheck.Application.Interfaces.Persistence;
using RuleCheck.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RuleCheck.Domain.Entities;

namespace RuleCheck.Infrastructure.Repositories;

public class RuleRepository : IRuleRepository
{
    private readonly RuleCheckDbContext _context;

    public RuleRepository(RuleCheckDbContext context)
    {
        _context = context;
    }

    public async Task<List<Rule>> GetAllAsync()
    {
        return await _context.Rules.ToListAsync();
    }

    public async Task<Rule?> GetByIdAsync(int id)
    {
        return await _context.Rules.FindAsync(id);
    }

    public async Task AddAsync(Rule rule)
    {
        await _context.Rules.AddAsync(rule);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Rule rule)
    {
        _context.Rules.Update(rule);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Rule rule)
    {
        _context.Rules.Remove(rule);
        await _context.SaveChangesAsync();
    }
}