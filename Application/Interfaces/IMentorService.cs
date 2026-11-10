using Application.DTOs.MentorByIdDtos;
using Application.DTOs.MentorDtos;
using Application.Responses;

namespace Application.Interfaces;

public interface IMentorService
{
    Task<ApiResponse<List<MentorDto>>> GetMentors();
    Task<ApiResponse<MentorByIdDto?>> GetMentor(int id);
    Task<ApiResponse<bool>> AddMentor(CreateMentorDto mentorDto);
    Task<ApiResponse<bool>> UpdateMentor(int id, UpdateMentorDto mentorDto);
    Task<ApiResponse<bool>> DeleteMentor(int id);
}
