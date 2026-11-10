namespace Application.DTOs.MentorDtos;

public class CreateMentorDto
{
    public string Fullname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Specialization { get; set; } = null!;
}
