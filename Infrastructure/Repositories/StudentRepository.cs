using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentRepository(AppDbContext appDbContext) : IStudentRepository
{
    private AppDbContext _context = appDbContext;

    public async Task AddStudent(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStudent(int id)
    {
        var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
        if (student == null)
            return;

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }

    public async Task<Student?> GetStudent(int id)
    {
        return await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
    }

    public async Task<List<Student>> GetStudents()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task UpdateStudent(Student student)
    {
        var existing = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == student.StudentId);
        if (existing == null)
            return;

        existing.Fullname = student.Fullname;
        existing.Email = student.Email;
        existing.Phone = student.Phone;
        existing.Enrollmentdate = student.Enrollmentdate;
        await _context.SaveChangesAsync();
    }
}
