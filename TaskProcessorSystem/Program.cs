using TaskProcessorSystem.Data;
using Microsoft.EntityFrameworkCore;
using TaskProcessorSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add SQLite DB context
builder.Services.AddDbContext<JobDbContext>(options =>
    options.UseSqlite("Data Source=jobs.db")); //This connect to SQLite DB

// Add hosted background job processor
builder.Services.AddHostedService<JobProcessorService>();

// Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200") 
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

// And in the middleware pipeline:
app.UseCors("AllowAngularApp");

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();  // Authorization middleware
app.MapControllers();    // Map controllers to endpoints
app.Run();               // Run the application