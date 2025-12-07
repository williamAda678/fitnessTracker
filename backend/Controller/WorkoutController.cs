using AutoMapper;
using FitnessTracker.Api.Models;
using FitnessTracker.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public WorkoutsController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkoutReadDto>>> GetWorkouts()
    {
        var workouts = await _context.Workouts.ToListAsync();
        return Ok(_mapper.Map<IEnumerable<WorkoutReadDto>>(workouts));
    }

    [HttpPost]
    public async Task<ActionResult<WorkoutReadDto>> CreateWorkout(WorkoutCreateDTO workoutDto)
    {
        var workout = _mapper.Map<Workout>(workoutDto);

        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();

        var readDto = _mapper.Map<WorkoutReadDto>(workout);

        return CreatedAtAction(nameof(GetWorkouts), new { id = workout.Id }, readDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkout(int id, WorkoutUpdateDto workoutDto)
    {
        var workout = await _context.Workouts.FindAsync(id);

        if (workout is null)
            return NotFound();

        _mapper.Map(workoutDto, workout);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkout(int id)
    {
        var workout = await _context.Workouts.FindAsync(id);

        if (workout is null)
            return NotFound();

        _context.Workouts.Remove(workout);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
