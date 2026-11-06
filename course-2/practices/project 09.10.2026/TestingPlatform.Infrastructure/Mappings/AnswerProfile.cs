using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Requests.Answer;
using TestingPlatform.Application.Responses.Answer;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Mappings;

public class AnswerProfile : Profile
{
    public AnswerProfile()
    {
        CreateMap<Answer, AnswerDto>().ReverseMap();

        CreateMap<CreateAnswerRequest, AnswerDto>();

        CreateMap<AnswerDto, AnswerResponse>();
    }
}
