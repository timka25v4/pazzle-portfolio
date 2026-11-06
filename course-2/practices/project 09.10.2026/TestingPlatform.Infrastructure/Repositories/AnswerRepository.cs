using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Infrastructure.Data;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Repositories;

public class AnswerRepository : IAnswerRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AnswerRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AnswerDto>> GetAllAsync()
    {
        var answers = await _context.Answers.ToListAsync();
        return _mapper.Map<IEnumerable<AnswerDto>>(answers);
    }

    public async Task<AnswerDto> GetByIdAsync(int id)
    {
        var test = await _context.Tests.FindAsync(id);
        return _mapper.Map<AnswerDto>(test);
    }

    public async Task AddAsync(AnswerDto answerDto)
    {
        var answer = _mapper.Map<Answer>(answerDto);
        await _context.Answers.AddAsync(answer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AnswerDto answerDto)
    {
        var answer = _mapper.Map<Answer>(answerDto);
        _context.Answers.Update(answer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var answer = await _context.Answers.FindAsync(id);
        if (answer != null)
        {
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
        }
    }
}
