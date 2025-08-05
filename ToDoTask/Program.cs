using ToDoTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using ToDoTask.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Правильная регистрация DbContext с параметрами
builder.Services.AddDbContext<ToDoTaskDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString(nameof(ToDoTaskDBContext)))); // Или другой провайдер БД

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Добавьте это для Swagger
builder.Services.AddSwaggerGen(); // Вместо AddOpenApi()

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