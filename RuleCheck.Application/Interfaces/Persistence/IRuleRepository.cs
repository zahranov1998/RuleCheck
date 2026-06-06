using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuleCheck.Domain.Entities;

namespace RuleCheck.Application.Interfaces.Persistence;

public interface IRuleRepository
{
    Task<List<Rule>> GetAllAsync();
    Task<Rule?> GetByIdAsync(int id);
    Task AddAsync(Rule rule);
    Task UpdateAsync(Rule rule);
    Task DeleteAsync(Rule rule);
}