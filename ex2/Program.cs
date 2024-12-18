using ex2.Models;
using ex2.Repositories;
using ex2.Services;
using ex2.Services.Logger;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TasksApi.Services.Logger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TasksContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<ITasksServices, TasksServices>();
builder.Services.AddScoped<IAttachmentsRepositories, AttachmentsRepository>();
builder.Services.AddScoped<IAttachmentsService, AttachmentsServices>();
builder.Services.AddScoped<ILoggerService, DbLogger>();




// Add services to the container.
builder.Services.AddControllers();
// Add Swagger services to the container.
builder.Services.AddEndpointsApiExplorer(); // For exposing endpoints
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Books API",
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
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasks API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
