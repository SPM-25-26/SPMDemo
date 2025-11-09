using Microsoft.EntityFrameworkCore;
using Serilog;
using SPMDemo.Data;
using SPMDemo.Endpoints;
using SPMDemo.Models.Services.Application.PointOfInterests;
using SPMDemo.Models.Services.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Serilog
builder.Host.UseSerilog((webHostBuilderContext, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(webHostBuilderContext.Configuration));

// Register UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register services
builder.Services.AddTransient<IPointOfInterestService, PointOfInterestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map endpoints
app.MapPointOfInterest();

app.Run();