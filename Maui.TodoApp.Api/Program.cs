using Maui.TodoApp.Api.Data;
using Maui.TodoApp.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"));
});

var app = builder.Build();



//app.UseHttpsRedirection();

app.MapGet("api/todo", async (AppDbContext context) =>
{
    var items = await context.ToDos.ToListAsync();
    return Results.Ok(items);
});


app.MapPost("api/todo", async (AppDbContext context, ToDo todo) =>
{
    await context.ToDos.AddAsync(todo);
    await context.SaveChangesAsync();
    return Results.Created($"api/todo/{todo.Id}", todo);
});

app.MapPut("api/todo/{id}", async (AppDbContext context, int id, ToDo todo) =>
{
    var todoModel = await context.ToDos.FirstOrDefaultAsync(t => t.Id == id);
    
    if(todoModel == null)
    {
        return Results.NotFound();
    }

    todoModel.ToDoName = todo.ToDoName;
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("api/todo/{id}", async (AppDbContext context, int id) =>
{
    var todoModel = await context.ToDos.FirstOrDefaultAsync(t => t.Id == id);

    if (todoModel == null)
    {
        return Results.NotFound();
    }
    context.ToDos.Remove(todoModel);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

