using Microsoft.AspNetCore.Mvc;
using RuleCheck.Application.Dtos.Validate;
using RuleCheck.Application.Interfaces.Services;

namespace RuleCheck.Api.Controllers;

[ApiController]
[Route("api/validation")]
public class ValidationController : ControllerBase
{
    private readonly IRuleEngine _ruleEngine;

    public ValidationController(IRuleEngine ruleEngine)
    {
        _ruleEngine = ruleEngine;
    }

    [HttpPost]
    public async Task<IActionResult> Validate(
        [FromBody] ValidateRequest request)
    {
        var result = await _ruleEngine.ValidateAsync(request);

        return Ok(result);
    }
}