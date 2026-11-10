using Domain.Enums;

namespace Application.DTOs.StudentGroupDtos;

public class StudentGroupDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public Status Status { get; set; }
}
