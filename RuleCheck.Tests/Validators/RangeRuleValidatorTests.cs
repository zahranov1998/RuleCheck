using FluentAssertions;
using RuleCheck.Domain.Entities;
using RuleCheck.Infrastructure.Services.Validators;

namespace RuleCheck.Tests.Validators;

public class RangeRuleValidatorTests
{
    private readonly RangeRuleValidator _validator;

    public RangeRuleValidatorTests()
    {
        _validator = new RangeRuleValidator();
    }

    [Fact]
    public void Validate_Should_ReturnTrue_When_ValueIsWithinRange()
    {
        var rule = new Rule
        {
            MinValue = 18,
            MaxValue = 60
        };

        var result = _validator.Validate(rule, 30);

        result.Should().BeTrue();
    }

    [Fact]
    public void Validate_Should_ReturnFalse_When_ValueIsLessThanMin()
    {
        var rule = new Rule
        {
            MinValue = 18,
            MaxValue = 60
        };

        var result = _validator.Validate(rule, 10);

        result.Should().BeFalse();
    }

    [Fact]
    public void Validate_Should_ReturnFalse_When_ValueIsGreaterThanMax()
    {
        var rule = new Rule
        {
            MinValue = 18,
            MaxValue = 60
        };

        var result = _validator.Validate(rule, 100);

        result.Should().BeFalse();
    }
}