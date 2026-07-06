# Copilot Instructions

## Stack
- .NET 10, C# 14
- Angular (frontend)
- Azure / GCP
- Terraform (infrastructure)

## Architecture
- Repository pattern for data access
- No business logic in controllers — delegate to services/handlers
- Prefer MediatR handlers (CQRS) for application logic if already used in the project
- Keep controllers thin: validate input, call handler, return result

## Error Handling
- Use result types or custom exceptions — no swallowing exceptions silently
- Validate at boundaries (controllers, public service methods); trust internals

## Testing Guidelines
- Use Name_StateUnderTest_Behavior test method names
- Add Arrange/Act/Assert (AAA) comments with blank lines
- Prefer FluentAssertions.BeEquivalentTo with anonymous objects when asserting multiple fields

# Git Commit Message Rules
When generating Git commit messages for staged changes, you must strictly follow these rules:
- Format the first line as: <type>(<Scope>): <short description>
- Allowed types: feat, fix, docs, style, refactor, perf, test, chore
- Keep the first line under 50 characters, all lowercase
- Leave one blank line, then write a bulleted list describing key changes
- As Scope use the name of the project or module affected by the changes. Do not make the name lowercase only, but remove extra prefix. If it too long - shorten.
- Be consice and clear in the description, focusing on what was changed and why but avoid unnecessary detail