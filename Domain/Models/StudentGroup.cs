using Domain.Enums;

namespace Domain.Models;

public class StudentGroup
{
    public int StudentGroupId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;
    public Status Status { get; set; }
}
