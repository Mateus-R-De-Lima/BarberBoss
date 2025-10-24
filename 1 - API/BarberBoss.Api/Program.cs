using BarberBoss.Api.Filters;
using BarberBoss.Api.Middleware;
using BarberBoss.Application;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExeceptionFilter)));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<CultureMiddleware>();

app.MapOpenApi();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
