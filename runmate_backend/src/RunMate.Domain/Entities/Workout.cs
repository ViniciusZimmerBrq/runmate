namespace RunMate.Domain.Entities;

public sealed class Workout
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string Title { get; private set; }
    public DateTime PerformedAt { get; init; }
    public double DistanceInKm { get; private set; }
    public int DurationInMinutes { get; private set; }

    public Workout(
        Guid id,
        Guid userId,
        string title,
        DateTime performedAt,
        double distanceInKm,
        int durationInMinutes)
    {
        Id = id;
        UserId = userId;
        Title = title;
        PerformedAt = performedAt;
        DistanceInKm = distanceInKm;
        DurationInMinutes = durationInMinutes;
    }
}
