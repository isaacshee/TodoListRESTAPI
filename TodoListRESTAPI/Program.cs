using Microsoft.EntityFrameworkCore;
using TodoListRESTAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//ISAAC - *IMPORTANT* creating database via migration using ConnectionString defined in appsettings.json
/*
For demonstration purposes, my connection string is hardcoded and set to my local database, but it is not best practice to hardcode the connectionstring
some ways for a more secure connectionstring:
1. Configuration files, i.e. do not upload appsettings.json
2. Environment Variables, i.e. setx ConnectionStrings__DefaultConnection "Server=myServerAddress;Database=myDatabase;User Id=myUsername;Password=myPassword;"
3. Secret Manager Tool i.e. storing the connectionstring in secrets.json by right-clicking your project and selecting Manage User Secrets
4. Key Vault (for production)
*/
builder.Services.AddDbContext<TodoItemContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddCors();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
