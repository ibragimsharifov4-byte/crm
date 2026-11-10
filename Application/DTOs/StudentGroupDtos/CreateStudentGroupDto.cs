using Domain.Enums;

namespace Application.DTOs.StudentGroupDtos;

public class CreateStudentGroupDto
{
    public int StudentGroupId { get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public Status Status { get; set; }
}
