namespace RunMate.Application.Dtos;

public sealed record WeeklySummaryDto(
    double DistanceInKm,
    int CompletedWorkouts,
    string AveragePace,
    int GoalProgress);
