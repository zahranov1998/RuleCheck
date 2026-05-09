using RuleCheck.Application.Dtos;
using RuleCheck.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Application.Services;

public class RuleService : IRuleService
{
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