using FluentAssertions;
using RuleCheck.Domain.Entities;
using RuleCheck.Infrastructure.Services.Validators;

namespace RuleCheck.Tests.Validators;

public class RegexRuleValidatorTests
{
    private readonly RegexRuleValidator _validator;

    public RegexRuleValidatorTests()
    {
        _validator = new RegexRuleValidator();
    }

    [Fact]
    public void Validate_Should_ReturnTrue_For_ValidEmail()
    {
        var rule = new Rule
        {
            Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
        };

        var result = _validator.Validate(rule, "john@test.com");

        result.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_ReturnFalse_For_InvalidEmail()
    {
        var rule = new Rule
        {
            Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
        };

        var result = _validator.Validate(rule, "wrong-email");

        result.Should().BeFalse();
    }

    [Fact]
    public void Validate_Should_ReturnFalse_When_ValueIsNull()
    {
        var rule = new Rule
        {
            Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
        };

        var result = _validator.Validate(rule, null);

        result.Should().BeFalse();
    }
}