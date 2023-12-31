using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var _config = builder.Configuration;
var connectionString = _config.GetConnectionString("DevConnection");

builder.Services.AddDbContext<TiendaWebContext>(Options => Options.UseSqlServer(ConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();<
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
