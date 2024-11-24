using Lesson3.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Lesson3.Repositories;
using Microsoft.Data.SqlClient;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TasksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services for Dependency Injection
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<ITasksService, TasksService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); // For exposing endpoints
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Tωγμ API",
        Description = "A simple example ASP.NET Core API to manage books",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com",
            Url = new Uri("https://yourwebsite.com"),
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.)
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
}
app.UseRouting(); // Adds routing to the request pipeline
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapGet("/", () => "Hello World!");

app.Run();
