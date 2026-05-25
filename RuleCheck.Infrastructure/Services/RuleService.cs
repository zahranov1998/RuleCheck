using RuleCheck.Application.Dtos;
using RuleCheck.Application.Interfaces;
using RuleCheck.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Infrastructure.Services;

public class RuleService : IRuleService
{
    private readonly RuleCheckDbContext _context;

    public RuleService(RuleCheckDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<RuleDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<RuleDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RuleDto> CreateAsync(RuleDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<RuleDto> UpdateAsync(int id, RuleDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}