# Task Processing System

## Technologies
- C#, .NET 8 Web API
- SQLite + Entity Framework Core
- Angular (Frontend)
- xUnit + Moq (Testing)

## Features
- Submit and track asynchronous jobs
- Retry logic on failures
- Swagger UI for API docs
- Angular UI to manage jobs

## Setup Instructions
1. Clone repo
2. Run `dotnet ef database update`
3. Start Web API: `dotnet run`
4. Start frontend: `ng serve`

## Design Decisions
- Used `IHostedService` for background tasks
- Used `Guid` for Job IDs
- Retry logic up to 3 times

## Assumptions
- Job payloads are JSON strings
- Simulated processing with `Task.Delay`