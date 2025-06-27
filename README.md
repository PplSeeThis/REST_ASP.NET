# Simple REST API with ASP.NET Core

A simple REST API for managing a to-do list, built with C# and ASP.NET Core (.NET 8). This project demonstrates backend development skills on an enterprise-level stack.

## 🛠️ Tech Stack

- C#
- ASP.NET Core 8
- .NET 8
- Minimal API

## Endpoints

- `GET /api/tasks` - Get a list of all tasks.
- `GET /api/tasks/{id}` - Get a single task by its ID.
- `POST /api/tasks` - Create a new task. Request body: `{ "text": "New task", "isCompleted": false }`.
- `DELETE /api/tasks/{id}` - Delete a task by its ID.

## ⚙️ Running Locally

To run this project, you need the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed.

1. Clone the repository.
2. Open a terminal in the project folder.
3. Run the command to start the server:
   ```bash
   dotnet run
The server will be available at the address shown in the console (usually http://localhost:5000 or similar).
