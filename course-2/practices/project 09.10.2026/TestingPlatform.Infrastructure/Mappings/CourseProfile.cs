using AutoMapper;
using practice.Responses.Course;
using TestingPlatform.Application.Dtos;

namespace practice.Mappings;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseDto, CourseResponse>();
    }
}