using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IMentorService
{
    Task<ApiResponse<List<Mentor>>> GetMentors();
    Task<ApiResponse<Mentor?>> GetMentor(int id);
    Task<ApiResponse<bool>> AddMentor(Mentor mentor);
    Task<ApiResponse<bool>> UpdateMentor(int id, Mentor mentor);
    Task<ApiResponse<bool>> DeleteMentor(int id);
}
