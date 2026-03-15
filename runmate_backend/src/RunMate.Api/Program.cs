using RunMate.Api.Endpoints;
using RunMate.Application.Dtos;
using RunMate.Application.DependencyInjection;
using RunMate.Infrastructure.DependencyInjection;
using RunMate.Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

// --- JWT secret guard: fail fast in non-development without a configured secret ---
var jwtSecret = builder.Configuration["Jwt:Secret"];
if (!builder.Environment.IsDevelopment() && string.IsNullOrWhiteSpace(jwtSecret))
{
    throw new InvalidOperationException(
        "JWT secret is missing. Set Jwt:Secret in configuration or the JWT__Secret environment variable before starting the API.");
}

// --- Service registration ---
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "RunMate API", Version = "v1" });
});

var app = builder.Build();

// --- Middleware ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// --- Health endpoints ---
app.MapGet("/health", () => Results.Ok(new { status = "ok" }))
    .WithTags("Health");

app.MapGet("/health/config", (IConfiguration config) =>
{
    var opts = config.GetSection(JwtOptions.SectionName).Get<JwtOptions>() ?? new JwtOptions();
    return Results.Ok(new
    {
        JwtIssuer = opts.Issuer,
        JwtAudience = opts.Audience,
        HasJwtSecret = !string.IsNullOrWhiteSpace(opts.Secret),
        Environment = app.Environment.EnvironmentName,
    });
}).WithTags("Health");

// --- Stub endpoints (kept for Flutter dashboard/workout screens) ---
app.MapGet("/api/dashboard/weekly-summary", () =>
    Results.Ok(
        new WeeklySummaryDto(
            DistanceInKm: 18.4,
            CompletedWorkouts: 4,
            AveragePace: "5:32/km",
            GoalProgress: 74)))
    .WithTags("Dashboard");

app.MapGet("/api/workouts", () =>
    Results.Ok(
        new[]
        {
            new WorkoutDto(
                Id: Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Title: "Rodagem leve",
                PerformedAt: new DateTime(2026, 3, 12, 6, 30, 0, DateTimeKind.Utc),
                DistanceInKm: 5.0,
                DurationInMinutes: 29,
                Pace: "5:48/km"),
        }))
    .WithTags("Workouts");

// --- Auth endpoints (real JWT) ---
app.MapAuthEndpoints();

app.Run();
