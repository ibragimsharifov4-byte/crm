namespace Application.DTOs.GroupDtos;

public class UpdateGroupDto
{
    public string GroupName { get; set; } = null!;
    public int CourseId { get; set; }
    public int MentorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
