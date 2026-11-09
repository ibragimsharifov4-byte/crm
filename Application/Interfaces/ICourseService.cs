using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface ICourseService
{
    Task<ApiResponse<List<Course>>> GetCourses();
    Task<ApiResponse<Course?>> GetCourse(int id);
    Task<ApiResponse<bool>> AddCourse(Course course);
    Task<ApiResponse<bool>> UpdateCourse(int id, Course course);
    Task<ApiResponse<bool>> DeleteCourse(int id);
}
