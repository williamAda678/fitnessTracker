using AutoMapper;
using FitnessTracker.Api.Models;

namespace FitnessTracker.Api.Profiles;

public class WorkoutProfile : Profile
{
    public WorkoutProfile()
    {
        CreateMap<Workout, WorkoutReadDto>();
        CreateMap<WorkoutCreateDTO, Workout>();
        CreateMap<WorkoutUpdateDto, Workout>();
    }
}
