using System;

namespace FitnessTracker.Api.Models;


public class WorkoutUpdateDto
{
    public string Exercise { get; set; } = string.Empty;
    public int Reps { get; set; }
    public int Sets { get; set; }
    public DateTime Date { get; set; }
}
