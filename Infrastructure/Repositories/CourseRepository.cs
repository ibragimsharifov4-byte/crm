using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CourseRepository(AppDbContext appDbContext) : ICourseRepository
{
    private AppDbContext _context = appDbContext;

    public async Task AddCourse(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCourse(int id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
        if (course == null)
            return;

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
    }

    public async Task<Course?> GetCourse(int id)
    {
        return await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
    }

    public async Task<List<Course>> GetCourses()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task UpdateCourse(Course course)
    {
        var existing = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == course.CourseId);
        if (existing == null)
            return;

        existing.Title = course.Title;
        existing.Description = course.Description;
        existing.Durationweek = course.Durationweek;
        await _context.SaveChangesAsync();
    }
}
