namespace Application.DTOs.CourseByIdDtos;

public class CourseByIdDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Durationweek { get; set; }
}
