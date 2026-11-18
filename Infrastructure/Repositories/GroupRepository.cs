using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GroupRepository(AppDbContext appDbContext) : IGroupRepository
{
    private AppDbContext _context = appDbContext;

    public async Task AddGroup(Group group)
    {
        _context.Groups.Add(group);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGroup(int id)
    {
        var group = await _context.Groups.FirstOrDefaultAsync(x => x.GroupId == id);
        if (group == null)
            return;

        _context.Groups.Remove(group);
        await _context.SaveChangesAsync();
    }

    public async Task<Group?> GetGroup(int id)
    {
        return await _context.Groups.FirstOrDefaultAsync(x => x.GroupId == id);
    }

    public async Task<List<Group>> GetGroups()
    {
        var groups = await _context.Groups.Include(e => e.Course).Include(e => e.Mentor).ToListAsync();
        return groups;
    }

    public async Task UpdateGroup(Group group)
    {
        var existing = await _context.Groups.FirstOrDefaultAsync(x => x.GroupId == group.GroupId);
        if (existing == null)
            return;

        existing.GroupName = group.GroupName;
        existing.CourseId = group.CourseId;
        existing.MentorId = group.MentorId;
        existing.StartDate = group.StartDate;
        existing.EndDate = group.EndDate;
        await _context.SaveChangesAsync();
    }
}
