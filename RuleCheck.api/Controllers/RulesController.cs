using Microsoft.AspNetCore.Mvc;
using RuleCheck.Application.Dtos;
using RuleCheck.Application.Interfaces;

namespace RuleCheck.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RulesController : ControllerBase
{
    private readonly IRuleService _ruleService;

    public RulesController(IRuleService ruleService)
    {
        _ruleService = ruleService;
    }

    [HttpGet]
    public async Task<IEnumerable<RuleDto>> GetAll()
    {
        return await _ruleService.GetAllAsync();
    }
}