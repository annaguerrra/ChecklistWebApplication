using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Task> tasks = [];

app.MapPost("Register", ([FromBody] Task task) =>
{
    if (task.Name is null || task.Name.Length == 0)
        return "The title task must contain at least 1(one) character";
    tasks.Add(task);
    return "Task added successfully";
});

app.MapGet("List", () tasks);

app.MapPatch("Check\{id}", (int id, [FromBody] Task task) =>
{
    if(task.ID == id)
    {
        task.Conclued = true;
        return "Task marked as conclued!";
    }
}); 
app.Run();

public record Task(
  int ID,
  string Name,
  bool Conclued
);
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Task> tasks = [];

app.MapPost("Register", ([FromBody] Task task) =>
{
    if (task.Name is null || task.Name.Length == 0)
        return "The title task must contain at least 1(one) character";
    tasks.Add(task);
    return "Task added successfully";
});

app.MapGet("List", () tasks);

app.MapPatch("Check\{id}", (int id, [FromBody] Task task) =>
{
    if(task.ID == id)
    {
        task.Conclued = true;
        return "Task marked as conclued!";
    }
}); 
app.Run();

public record Task(
  int ID,
  string Name,
  bool Conclued
);
