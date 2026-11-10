using Application.DTOs.CourseByIdDtos;
using Application.DTOs.CourseDtos;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface ICourseService
{
    Task<ApiResponse<List<CourseDto>>> GetCourses();
    Task<ApiResponse<CourseByIdDto?>> GetCourse(int id);
    Task<ApiResponse<bool>> AddCourse(CreateCourseDto courseDto);
    Task<ApiResponse<bool>> UpdateCourse(int id, UpdateCourseDto courseDto);
    Task<ApiResponse<bool>> DeleteCourse(int id);
}
