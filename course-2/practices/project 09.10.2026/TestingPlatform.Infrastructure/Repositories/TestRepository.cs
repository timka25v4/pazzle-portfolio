using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Infrastructure.Data;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Repositories;

public class TestRepository : ITestRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TestRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TestDto>> GetAllAsync()
    {
        var tests = await _context.Tests.ToListAsync();
        return _mapper.Map<IEnumerable<TestDto>>(tests);
    }

    public async Task<TestDto> GetByIdAsync(int id)
    {
        var test = await _context.Tests.FindAsync(id);
        return _mapper.Map<TestDto>(test);
    }

    public async Task AddAsync(TestDto testDto)
    {
        var test = _mapper.Map<Test>(testDto);
        await _context.Tests.AddAsync(test);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TestDto testDto)
    {
        var test = _mapper.Map<Test>(testDto);
        _context.Tests.Update(test);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var test = await _context.Tests.FindAsync(id);
        if (test != null)
        {
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
        }
    }
}
