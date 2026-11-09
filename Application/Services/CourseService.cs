using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    private readonly ICourseRepository _repository = courseRepository;

    public async Task<ApiResponse<List<Course>>> GetCourses()
    {
        var result = await _repository.GetCourses();
        return new ApiResponse<List<Course>>(HttpStatusCode.OK, "Courses retrieved successfully", result);
    }

    public async Task<ApiResponse<Course?>> GetCourse(int id)
    {
        if (id <= 0)
        return new ApiResponse<Course?>(HttpStatusCode.BadRequest, "Invalid course id", null);
        var result = await _repository.GetCourse(id);
        return result != null
        ? new ApiResponse<Course?>(HttpStatusCode.OK, "Course retrieved successfully", result)
        : new ApiResponse<Course?>(HttpStatusCode.NotFound, "Course not found", null);
    }

    public async Task<ApiResponse<bool>> AddCourse(Course course)
    {
        if (course == null || string.IsNullOrWhiteSpace(course.Title) || string.IsNullOrWhiteSpace(course.Description))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid course data", false);
        await _repository.AddCourse(course);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Course added successfully", true);
    }

    public async Task<ApiResponse<bool>> UpdateCourse(int id, Course course)
    {
        if (id <= 0 || course == null || string.IsNullOrWhiteSpace(course.Title) || string.IsNullOrWhiteSpace(course.Description))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid course data", false);
        if (await _repository.GetCourse(id) == null)
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Course not found", false);

        course.CourseId = id;
        await _repository.UpdateCourse(course);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Course updated successfully", true);
    }

    public async Task<ApiResponse<bool>> DeleteCourse(int id)
    {
        if (id <= 0)
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid course id", false);

        if (await _repository.GetCourse(id) == null)
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Course not found", false);

        await _repository.DeleteCourse(id);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Course deleted successfully", true);
    }
}
