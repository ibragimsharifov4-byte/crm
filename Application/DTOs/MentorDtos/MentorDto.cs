namespace Application.DTOs.MentorDtos;

public class MentorDto
{
    public int Id { get; set; }
    public string Fullname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Specialization { get; set; } = null!;
}
