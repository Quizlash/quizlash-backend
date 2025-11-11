using Quizlash_App.Authentication;
using Quizlash_App.Database.PostgreSql;
using Quizlash_App.Databases;
using Quizlash_App.Wolverine;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDatabases(builder.Configuration);
builder .Services.AddAuthentication(builder.Configuration);
builder.Services.AddWolverines(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
