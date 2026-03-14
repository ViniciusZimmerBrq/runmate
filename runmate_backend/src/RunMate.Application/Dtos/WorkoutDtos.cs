namespace RunMate.Application.Dtos;

public sealed record WorkoutDto(
    Guid Id,
    string Title,
    DateTime PerformedAt,
    double DistanceInKm,
    int DurationInMinutes,
    string Pace);
