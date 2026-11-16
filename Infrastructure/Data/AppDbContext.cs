using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Mentor> Mentors { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }
}
