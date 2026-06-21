using RuleCheck.Application.Dtos.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleCheck.Application.Interfaces.Services;

public interface IRuleEngine
{
    Task<ValidateResponse> ValidateAsync(ValidateRequest request);

}