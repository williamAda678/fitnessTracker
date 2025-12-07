namespace FitnessTracker.Api.Models;

public class Workout
{
    public int Id { get; set; }
    public string Exercise { get; set; } = string.Empty;
    public int Reps { get; set; }
    public int Sets { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
}