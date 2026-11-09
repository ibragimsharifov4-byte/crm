using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IStudentService
{
    Task<ApiResponse<List<Student>>> GetStudents();
    Task<ApiResponse<Student?>> GetStudent(int id);
    Task<ApiResponse<bool>> AddStudent(Student student);
    Task<ApiResponse<bool>> UpdateStudent(int id, Student student);
    Task<ApiResponse<bool>> DeleteStudent(int id);
}
