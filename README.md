# RuleCheck

RuleCheck is a rule-based validation engine built with ASP.NET Core.

Instead of hardcoding validation logic, validation rules are stored in SQL Server and evaluated dynamically at runtime. The project is designed using Clean Architecture and demonstrates common backend design patterns such as Repository Pattern, Strategy Pattern, and Dependency Injection.

## Features

- Manage validation rules through REST APIs
- Execute validation rules dynamically
- Support multiple rule types:
  - Required
  - Regex
  - Range
- Extensible validation pipeline using Strategy Pattern
- Unit tested with xUnit, Moq and FluentAssertions

## Tech Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Clean Architecture
- Repository Pattern
- Strategy Pattern
- FluentValidation
- xUnit
- Moq
- FluentAssertions

## Project Structure

```
RuleCheck.API
RuleCheck.Application
RuleCheck.Domain
RuleCheck.Infrastructure
RuleCheck.Tests
```

## Sample Request

```json
{
  "data": {
    "FirstName": "",
    "Email": "wrong-email",
    "Age": 15
  }
}
```

## Sample Response

```json
{
  "isValid": false,
  "errors": [
    "First name is required",
    "Invalid email format",
    "Age must be between 18 and 60"
  ]
}
```

## Running the project

```bash
git clone https://github.com/zahranov1998/RuleCheck.git

dotnet ef database update

dotnet run
```

Update the SQL Server connection string in `appsettings.json` before running the application.

## Future Improvements

- Docker support
- Integration tests
- CI/CD with GitHub Actions
- Additional validation strategies
