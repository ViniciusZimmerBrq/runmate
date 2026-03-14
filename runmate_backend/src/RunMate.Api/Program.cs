using Microsoft.AspNetCore.Mvc;
using RunMate.Application.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/api/dashboard/weekly-summary", () =>
    Results.Ok(
        new WeeklySummaryDto(
            DistanceInKm: 18.4,
            CompletedWorkouts: 4,
            AveragePace: "5:32/km",
            GoalProgress: 74)));

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
        }));

app.MapPost("/api/auth/register", ([FromBody] RegisterRequestDto request) =>
{
    return Results.Created(
        "/api/users/me",
        new
        {
            request.Name,
            request.Email,
            Message = "Conta criada com sucesso.",
        });
});

app.MapPost("/api/auth/login", ([FromBody] LoginRequestDto request) =>
{
    return Results.Ok(
        new AuthResponseDto(
            AccessToken: "dev-token",
            RefreshToken: "dev-refresh-token",
            ExpiresInSeconds: 3600,
            UserName: request.Email));
});

app.Run();
