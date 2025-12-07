using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using Serilog;
using SPMDemo.Data;
using SPMDemo.Endpoints;
using SPMDemo.Models.Options;
using SPMDemo.Models.Services.Application.PointOfInterests;
using SPMDemo.Models.Services.Infrastructure;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Retrieve and configure the database connection string
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Register the DbContext with SQL Server provider
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddOpenApi();

// Developer exception page for EF migrations
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Retrieve the JWT secret key from configuration
var key = builder.Configuration["Jwt:Secret"]
    ?? throw new InvalidOperationException("JWT secret not configured");

// Configure JWT Bearer authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // Not validating issuer for simplicity
            ValidateAudience = false, // Not validating audience for simplicity
            ValidateIssuerSigningKey = true, // Validate the signing key
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // Secret key
        };
    });

// Enable authorization services
builder.Services.AddAuthorization();

// Configure Serilog logging
builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

// Register Unit of Work pattern
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register application services
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IPointOfInterestService, PointOfInterestService>();

// Bind JWT configuration section to strongly-typed options
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Enforce HTTPS
app.UseHttpsRedirection();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Map REST endpoints from extension methods
app.MapAuth();
app.MapPointOfInterest();

// Start the application
app.Run();
