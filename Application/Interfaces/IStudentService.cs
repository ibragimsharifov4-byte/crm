using Application.DTOs.StudentByIdDtos;
using Application.DTOs.StudentDtos;
using Application.Responses;

namespace Application.Interfaces;

public interface IStudentService
{
    Task<ApiResponse<List<StudentDto>>> GetStudents();
    Task<ApiResponse<StudentByIdDto?>> GetStudent(int id);
    Task<ApiResponse<bool>> AddStudent(CreateStudentDto studentDto);
    Task<ApiResponse<bool>> UpdateStudent(int id, UpdateStudentDto studentDto);
    Task<ApiResponse<bool>> DeleteStudent(int id);
}
