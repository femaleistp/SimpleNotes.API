# SimpleNotes Web API with Integration Tests

This project demonstrates a simple RESTful Web API for managing notes, along with xUnit-based integration tests.

## Projects

- `SimpleNotes.Api`: The main API project with CRUD endpoints (GET, POST, PUT, DELETE).
- `SimpleNotes.Tests`: The integration test project using xUnit and WebApplicationFactory.

## Screenshots

See the `Screenshots Assignment` folder:
- `Screenshots CRUD/`: Manual Swagger test screenshots
- `Screenshots Tests/`: Test Explorer showing passing tests

## How to Use

1. Open `SimpleNotes.sln` in Visual Studio.
2. Run the API (F5 or Ctrl+F5).
3. Navigate to: [http://localhost:5000/swagger](http://localhost:5000/swagger)
4. Run integration tests via **Test > Test Explorer**.

## Features

- REST endpoints using ASP.NET Core Web API
- Dependency Injection for NoteService
- Integration testing using `Microsoft.AspNetCore.Mvc.Testing`
