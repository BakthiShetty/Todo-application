using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;
using Todo.Infrastructure.Persistence;
using Todo.Infrastructure.Repositories;
using Todo.Application.Commands.CreateTodo; // to point MediatR scanning at Application assembly

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register DbContext (InMemory)
//builder.Services.AddDbContext<TodoDbContext>(options =>
//    options.UseInMemoryDatabase("TodoDb"));
var connection = builder.Configuration.GetConnectionString("TodoDb");

builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlServer(connection));


// Register repository (Application defines interface, Infrastructure implements)
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// Register MediatR and scan the Application assembly for handlers
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTodoCommand).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var allowedOrigins = "_allowedOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:5173") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();


app.UseCors(allowedOrigins);
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();


