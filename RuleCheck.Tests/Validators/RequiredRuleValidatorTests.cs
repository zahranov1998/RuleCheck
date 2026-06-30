using FluentAssertions;
using RuleCheck.Domain.Entities;
using RuleCheck.Infrastructure.Services.Validators;

namespace RuleCheck.Tests.Validators;

public class RequiredRuleValidatorTests
{
    private readonly RequiredRuleValidator _validator;

    public RequiredRuleValidatorTests()
    {
        _validator = new RequiredRuleValidator();
    }

    [Fact]
    public void Validate_Should_ReturnFalse_When_ValueIsNull()
    {
        // Arrange
        Rule rule = new();

        // Act
        var result = _validator.Validate(rule, null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Validate_Should_ReturnFalse_When_ValueIsEmpty()
    {
        Rule rule = new();

        var result = _validator.Validate(rule, "");

        result.Should().BeFalse();
    }

    [Fact]
    public void Validate_Should_ReturnTrue_When_ValueExists()
    {
        Rule rule = new();

        var result = _validator.Validate(rule, "John");

        result.Should().BeTrue();
    }
}