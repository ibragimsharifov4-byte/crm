namespace Application.DTOs.CourseDtos;

public class UpdateCourseDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Durationweek { get; set; }
}
