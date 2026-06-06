using RuleCheck.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Application.Interfaces;

public interface IRuleService
{
    Task<IEnumerable<RuleResponse>> GetAllAsync();
    Task<RuleResponse?> GetByIdAsync(int id);
    Task<RuleResponse> CreateAsync(CreateRuleRequest request);
    Task<RuleResponse?> UpdateAsync(int id, UpdateRuleRequest request);
    Task<bool> DeleteAsync(int id);
}