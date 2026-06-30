using FluentAssertions;
using Moq;
using RuleCheck.Application.Dtos.Validate;
using RuleCheck.Application.Interfaces.Persistence;
using RuleCheck.Application.Interfaces.Services;
using RuleCheck.Domain.Entities;
using RuleCheck.Domain.Enums;
using RuleCheck.Infrastructure.Services;
using RuleCheck.Infrastructure.Services.Validators;

namespace RuleCheck.Tests.Services;

public class RuleEngineTests
{
    private readonly Mock<IRuleRepository> _repositoryMock;
    private readonly IRuleEngine _ruleEngine;

    public RuleEngineTests()
    {
        _repositoryMock = new Mock<IRuleRepository>();

        var validators = new List<IRuleValidator>
        {
            new RequiredRuleValidator(),
            new RegexRuleValidator(),
            new RangeRuleValidator()
        };

        _ruleEngine = new RuleEngine(
            _repositoryMock.Object,
            validators);
    }

    [Fact]
    public async Task ValidateAsync_Should_ReturnErrors_When_RequestIsInvalid()
    {
        var rules = new List<Rule>
        {
            new()
            {
                FieldName = "FirstName",
                RuleType = RuleType.Required,
                ErrorMessage = "First name is required",
                IsActive = true
            },
            new()
            {
                FieldName = "Email",
                RuleType = RuleType.Regex,
                Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                ErrorMessage = "Invalid email format",
                IsActive = true
            },
            new()
            {
                FieldName = "Age",
                RuleType = RuleType.Range,
                MinValue = 18,
                MaxValue = 60,
                ErrorMessage = "Age must be between 18 and 60",
                IsActive = true
            }
        };

        _repositoryMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(rules);

        var request = new ValidateRequest
        {
            Data = new Dictionary<string, object>
            {
                { "FirstName", "" },
                { "Email", "wrong-email" },
                { "Age", 15 }
            }
        };

        var result = await _ruleEngine.ValidateAsync(request);

        result.IsValid.Should().BeFalse();

        result.Errors.Should().HaveCount(3);

        result.Errors.Should().Contain("First name is required");
        result.Errors.Should().Contain("Invalid email format");
        result.Errors.Should().Contain("Age must be between 18 and 60");
    }

    [Fact]
    public async Task ValidateAsync_Should_ReturnValid_When_RequestIsValid()
    {
        // Arrange

        var rules = new List<Rule>
        {
            new()
            {
                FieldName = "FirstName",
                RuleType = RuleType.Required,
                ErrorMessage = "First name is required",
                IsActive = true
            },
            new()
            {
                FieldName = "Email",
                RuleType = RuleType.Regex,
                Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                ErrorMessage = "Invalid email format",
                IsActive = true
            },
            new()
            {
                FieldName = "Age",
                RuleType = RuleType.Range,
                MinValue = 18,
                MaxValue = 60,
                ErrorMessage = "Age must be between 18 and 60",
                IsActive = true
            }
        };

        _repositoryMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(rules);

        var request = new ValidateRequest
        {
            Data = new Dictionary<string, object>
            {
                { "FirstName", "John" },
                { "Email", "john@test.com" },
                { "Age", 30 }
            }
        };

        var result = await _ruleEngine.ValidateAsync(request);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public async Task ValidateAsync_Should_IgnoreInactiveRules()
    {
        var rules = new List<Rule>
        {
            new()
            {
                FieldName = "FirstName",
                RuleType = RuleType.Required,
                ErrorMessage = "First name is required",
                IsActive = false
            }
        };

        _repositoryMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(rules);

        var request = new ValidateRequest();

        var result = await _ruleEngine.ValidateAsync(request);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public async Task ValidateAsync_Should_ReturnValid_When_NoRulesExist()
    {
        _repositoryMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<Rule>());

        var request = new ValidateRequest
        {
            Data = new Dictionary<string, object>()
        };

        var result = await _ruleEngine.ValidateAsync(request);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }
}