using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Task> tasks = [];

app.MapPost("Register", ([FromBody] Task task) =>
{
    if (task.Title is null || task.Title.Length == 0)
        return Results.BadRequest("The title task must contain at least 1(one) character");
    tasks.Add(task);
    return Results.Ok("Task added successfully");
});

app.MapGet("List", () => tasks);

app.MapPatch("Check/{id}", (int id, [FromBody] Task task) =>
{
    if (task.ID == id)
    {
        task.Conclued = true;
        return Results.Ok("Task marked as conclued!"); 
    }
    return Results.BadRequest("Item not found.");
}); 
app.Run();

public class Task
{
    public int ID { get; set; }
    public string Title { get; set; } 
    public bool Conclued{ get; set; }
    

}
