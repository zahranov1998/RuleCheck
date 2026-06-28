using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RuleCheck.Application.Dtos.Rules;
using RuleCheck.Domain.Enums;

namespace RuleCheck.Application.Validation;

public class CreateRuleRequestValidator : AbstractValidator<CreateRuleRequest>
{
    public CreateRuleRequestValidator()
    {
        RuleFor(x => x.FieldName)
            .NotEmpty()
            .WithMessage("Field name is required.")
            .MaximumLength(100)
            .WithMessage("Field name cannot exceed 100 characters.");

        RuleFor(x => x.ErrorMessage)
            .NotEmpty()
            .WithMessage("Error message is required.")
            .MaximumLength(500)
            .WithMessage("Error message cannot exceed 500 characters.");

        RuleFor(x => x.RuleType)
            .IsInEnum()
            .WithMessage("Invalid rule type.");

        // Regex rules must provide a pattern
        When(x => x.RuleType == RuleType.Regex, () =>
        {
            RuleFor(x => x.Pattern)
                .NotEmpty()
                .WithMessage("Pattern is required for Regex rules.");
        });

        // Range rules must provide min and max values
        When(x => x.RuleType == RuleType.Range, () =>
        {
            RuleFor(x => x.MinValue)
                .NotNull()
                .WithMessage("MinValue is required for Range rules.");

            RuleFor(x => x.MaxValue)
                .NotNull()
                .WithMessage("MaxValue is required for Range rules.");

            RuleFor(x => x)
                .Must(x => x.MinValue <= x.MaxValue)
                .WithMessage("MinValue must be less than or equal to MaxValue.");
        });
    }
}