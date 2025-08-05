using ToDoTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using ToDoTask.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// ���������� ����������� DbContext � �����������
builder.Services.AddDbContext<ToDoTaskDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString(nameof(ToDoTaskDBContext)))); // ��� ������ ��������� ��

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // �������� ��� ��� Swagger
builder.Services.AddSwaggerGen(); // ������ AddOpenApi()

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