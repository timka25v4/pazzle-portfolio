using AutoMapper;
using practice.Responses.Project;
using TestingPlatform.Application.Dtos;

namespace practice.Mappings;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<ProjectDto, ProjectResponse>();
    }
}

