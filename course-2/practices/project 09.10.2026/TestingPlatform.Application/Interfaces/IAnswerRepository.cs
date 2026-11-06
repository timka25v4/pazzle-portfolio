using TestingPlatform.Application.Dtos;

namespace TestingPlatform.Application.Interfaces;

public interface IAnswerRepository
{
    Task<IEnumerable<AnswerDto>> GetAllAsync();
    Task<AnswerDto> GetByIdAsync(int id);
    Task AddAsync(AnswerDto answerDto);
    Task UpdateAsync(AnswerDto answerDto);
    Task DeleteAsync(int id);
}
