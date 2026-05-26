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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var rule = await _ruleService.GetByIdAsync(id);
        return rule is null ? NotFound() : Ok(rule);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RuleDto dto)
    {
        var created = await _ruleService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] RuleDto dto)
    {
        var updated = await _ruleService.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _ruleService.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }

}