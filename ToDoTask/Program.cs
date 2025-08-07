using ToDoTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using ToDoTask.DataAccess;
using ToDoTask.Application.Services;
using ToDoTask.DataAccess.Reposotories;

var builder = WebApplication.CreateBuilder(args);

// Правильная регистрация DbContext с параметрами
builder.Services.AddDbContext<ToDoTaskDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(ToDoTaskDBContext)))); // Или другой провайдер БД

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Добавьте это для Swagger
builder.Services.AddSwaggerGen(); // Вместо AddOpenApi()
builder.Services.AddScoped<IToDoTaskService, ToDoTaskService>();
builder.Services.AddScoped<IToDoTaskReposotory, ToDoTaskReposotory>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();