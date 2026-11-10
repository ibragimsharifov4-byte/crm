namespace Application.DTOs.CourseDtos;

public class CreateCourseDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Durationweek { get; set; }
}
