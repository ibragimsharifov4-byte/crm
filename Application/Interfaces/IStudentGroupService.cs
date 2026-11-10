using Application.DTOs.StudentGroupDtos;
using Application.Responses;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    Task<ApiResponse<List<StudentGroupDto>>> GetStudentGroups();
    Task<ApiResponse<bool>> AddStudentGroup(CreateStudentGroupDto studentGroupDto);
    Task<ApiResponse<bool>> UpdateStudentGroup(UpdateStudentGroupDto studentGroupDto);
    Task<ApiResponse<bool>> DeleteStudentGroup(int id);
}
