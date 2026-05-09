using RuleCheck.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Application.Interfaces;

public interface IRuleService
{
    Task<IEnumerable<RuleDto>> GetAllAsync();
    Task<RuleDto?> GetByIdAsync(int id);
    Task<RuleDto> CreateAsync(RuleDto dto);
    Task<RuleDto> UpdateAsync(int id, RuleDto dto);
    Task<bool> DeleteAsync(int id);
}