using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

// --- WebApplication Setup ---
var builder = WebApplication.CreateBuilder(args);

// Add CORS service to allow requests from other origins (e.g., your React app)
builder.Services.AddCors();

var app = builder.Build();

// Use CORS
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// --- Data Model and In-Memory Data Store ---
public class TaskItem
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public bool IsCompleted { get; set; }
}

var tasks = new List<TaskItem>
{
    new TaskItem { Id = 1, Text = "Learn ASP.NET Core API", IsCompleted = false },
    new TaskItem { Id = 2, Text = "Upload project to GitHub", IsCompleted = true },
    new TaskItem { Id = 3, Text = "Create a professional portfolio", IsCompleted = false }
};

// --- API Endpoint Definitions ---

// GET /api/tasks - Get all tasks
app.MapGet("/api/tasks", () => tasks);

// GET /api/tasks/{id} - Get a task by ID
app.MapGet("/api/tasks/{id}", (int id) => 
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    return task is not null ? Results.Ok(task) : Results.NotFound("Task not found.");
});

// POST /api/tasks - Create a new task
app.MapPost("/api/tasks", (TaskItem task) => 
{
    task.Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
    tasks.Add(task);
    return Results.Created($"/api/tasks/{task.Id}", task);
});

// DELETE /api/tasks/{id} - Delete a task by ID
app.MapDelete("/api/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task is not null)
    {
        tasks.Remove(task);
        return Results.NoContent();
    }
    return Results.NotFound("Task not found.");
});

// --- Run the application ---
app.Run();
