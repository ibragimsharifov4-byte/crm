using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MentorRepository(AppDbContext appDbContext) : IMentorRepository
{
    private AppDbContext _context = appDbContext;

    public async Task AddMentor(Mentor mentor)
    {
        _context.Mentors.Add(mentor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMentor(int id)
    {
        var mentor = await _context.Mentors.FirstOrDefaultAsync(x => x.MentorId == id);
        if (mentor == null)
            return;

        _context.Mentors.Remove(mentor);
        await _context.SaveChangesAsync();
    }

    public async Task<Mentor?> GetMentor(int id)
    {
        return await _context.Mentors.FirstOrDefaultAsync(x => x.MentorId == id);
    }

    public async Task<List<Mentor>> GetMentors()
    {
        return await _context.Mentors.ToListAsync();
    }

    public async Task UpdateMentor(Mentor mentor)
    {
        var existing = await _context.Mentors.FirstOrDefaultAsync(x => x.MentorId == mentor.MentorId);
        if (existing == null)
            return;

        existing.Fullname = mentor.Fullname;
        existing.Email = mentor.Email;
        existing.Phone = mentor.Phone;
        existing.Specialization = mentor.Specialization;
        await _context.SaveChangesAsync();
    }
}
