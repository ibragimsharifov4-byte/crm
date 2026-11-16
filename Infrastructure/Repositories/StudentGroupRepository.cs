using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentGroupRepository(AppDbContext appDbContext) : IStudentGroupRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddStudentGroup(StudentGroup studentGroup)
    {
        _context.StudentGroups.Add(studentGroup);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteStudentGroup(int id)
    {
        var studentGroup = await _context.StudentGroups.FirstOrDefaultAsync(x => x.StudentGroupId == id);
        if (studentGroup == null)
            return false;

        _context.StudentGroups.Remove(studentGroup);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<List<StudentGroup>> GetStudentGroups()
    {
        return await _context.StudentGroups.ToListAsync();
    }

    public async Task<bool> UpdateStudentGroup(StudentGroup studentGroup)
    {
        var existing = await _context.StudentGroups.FirstOrDefaultAsync(x => x.StudentGroupId == studentGroup.StudentGroupId);
        if (existing == null)
            return false;

        existing.StudentId = studentGroup.StudentId;
        existing.GroupId = studentGroup.GroupId;
        existing.Status = studentGroup.Status;
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
