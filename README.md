# CQRS Todo API

A Todo Management REST API built with **ASP.NET Core Web API**, implementing the **CQRS (Command Query Responsibility Segregation)** pattern using MediatR and Entity Framework Core.

The project follows a layered architecture to separate business logic, application use cases, API endpoints, and data access.

## Features

- Create a Todo item.
- Retrieve all Todo items.
- Retrieve a Todo item by its ID.
- Update an existing Todo item.
- Delete a Todo item.
- Separate commands and queries using CQRS.
- MediatR for request and handler dispatching.
- Entity Framework Core for database operations.
- SQL Server for data persistence.
- Swagger UI for API documentation.

## Technology Stack

| Technology | Purpose |
|---|---|
| C# | Programming language |
| .NET 9 | Backend framework |
| ASP.NET Core Web API | REST API development |
| MediatR | CQRS implementation |
| Entity Framework Core | ORM and database access |
| SQL Server | Relational database |
| Swagger | API documentation |

## Architecture

The project is divided into four layers:

```text
TodoApp
│
└── src
    ├── Todo.API
    │   ├── Controllers
    │   └── Contracts
    │
    ├── Todo.Application
    │   ├── Commands
    │   ├── Queries
    │   └── Interfaces
    │
    ├── Todo.Domain
    │   └── Entities
    │
    └── Todo.Infrastructure
        ├── Persistence
        └── Repositories
```

### Layer Responsibilities

**1. Todo.API**
- Exposes REST API endpoints through controllers.
- Accepts HTTP requests and returns HTTP responses.
- Sends commands and queries to MediatR.

**2. Todo.Application**
- Contains application-specific business operations.
- Defines commands for write operations.
- Defines queries for read operations.
- Contains handlers that execute these operations.
- Defines repository interfaces.

**3. Todo.Domain**
- Contains core domain entities.
- Defines the `TodoItem` entity.

**4. Todo.Infrastructure**
- Implements repository interfaces.
- Handles database operations using Entity Framework Core.
- Contains the database context.

## Understanding CQRS

CQRS stands for Command Query Responsibility Segregation.

It separates operations that modify data from operations that retrieve data.

### Commands (Write Operations)

Commands change the application state.

| Command | Description |
|---|---|
| `CreateTodoCommand` | Creates a new Todo item |
| `UpdateTodoCommand` | Updates an existing Todo item |
| `DeleteTodoCommand` | Deletes a Todo item |

### Queries (Read Operations)

Queries retrieve data without modifying it.

| Query | Description |
|---|---|
| `GetTodosQuery` | Retrieves all Todo items |
| `GetTodoByIdQuery` | Retrieves a Todo item by ID |

MediatR dispatches each request to its corresponding handler, keeping the controller separate from the application logic.

## Getting Started

### Prerequisites

Install the following:

- .NET 9 SDK
- SQL Server (LocalDB, SQL Server Express, or another SQL Server instance)
- Visual Studio or Visual Studio Code

### 1. Clone the Repository

```bash
git clone <your-repository-url>
cd cqrs-todo
```

### 2. Configure the Database

Configure the SQL Server connection string using the `TodoDb` connection string setting.

For example, on PowerShell:

```powershell
$env:ConnectionStrings__TodoDb="Server=localhost;Database=CqrsTodo;Trusted_Connection=True;TrustServerCertificate=True;"
```

Use a SQL Server instance that is available on your machine and ensure the database exists.

Avoid committing passwords or other credentials to source control.

### 3. Restore Dependencies

```bash
dotnet restore TodoApp.sln
```

### 4. Run the Application

```bash
dotnet run --project src/Todo.API
```

The API uses the following development URLs:

```text
HTTP:  http://localhost:5051
HTTPS: https://localhost:7282
```

### 5. Explore the API

Open Swagger UI in your browser:

```text
http://localhost:5051/swagger
```

You can use Swagger to explore and test the available endpoints.

## API Endpoints

Base URL:

```text
/api/todos
```

| HTTP Method | Endpoint | Description |
|---|---|---|
| POST | `/api/todos` | Create a Todo |
| GET | `/api/todos` | Retrieve all Todos |
| GET | `/api/todos/{id}` | Retrieve a Todo by ID |
| PUT | `/api/todos/{id}` | Update a Todo |
| DELETE | `/api/todos/{id}` | Delete a Todo |

### Example Requests

**Create a Todo**

`POST /api/todos`

```json
{
  "title": "Learn CQRS",
  "description": "Understand commands, queries, and handlers"
}
```

**Update a Todo**

`PUT /api/todos/{id}`

```json
{
  "title": "Learn CQRS",
  "description": "Practice implementing CQRS with MediatR",
  "isCompleted": true
}
```

**Get All Todos**

`GET /api/todos`

**Get Todo by ID**

`GET /api/todos/{id}`

**Delete a Todo**

`DELETE /api/todos/{id}`

## Todo Entity

Each Todo item contains the following properties:

| Property | Type | Description |
|---|---|---|
| Id | Guid | Unique identifier |
| Title | string | Todo title |
| Description | string? | Optional description |
| IsCompleted | bool | Completion status |
| CreatedAt | DateTime | Creation timestamp |

## Key Concepts Demonstrated

- CQRS pattern
- MediatR request and handler implementation
- Separation of commands and queries
- Clean, layered architecture
- Dependency Injection
- Repository pattern
- Entity Framework Core
- RESTful API development

## Future Enhancements

- Input validation
- Global exception handling
- Unit and integration testing
- Database migrations
- Authentication and authorization
- Pagination and filtering

---

**Project:** CQRS Todo API  
**Framework:** ASP.NET Core 9  
**Database:** SQL Server