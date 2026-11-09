using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    Task<ApiResponse<List<StudentGroup>>> GetStudentGroups();
    Task<ApiResponse<bool>> AddStudentGroup(StudentGroup studentGroup);
    Task<ApiResponse<bool>> UpdateStudentGroup(StudentGroup studentGroup);
    Task<ApiResponse<bool>> DeleteStudentGroup(int id);
}
