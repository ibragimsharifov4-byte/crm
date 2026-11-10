using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Application.DTOs.CourseDtos;
using Application.DTOs.CourseByIdDtos;


namespace Application.Services;

public class CourseService(ICourseRepository courseRepository) : ICourseService
{
    private readonly ICourseRepository _repository = courseRepository;

    public async Task<ApiResponse<List<CourseDto>>> GetCourses()
    {
        var result = await _repository.GetCourses();

        var coursesDto = new List<CourseDto>();

        foreach (var c in result)
        {
            var courseDto = new CourseDto
            {
                Id = c.CourseId,
                Title = c.Title,
                Description = c.Description,
                Durationweek = c.Durationweek
            };

            coursesDto.Add(courseDto);
        }

        return new ApiResponse<List<CourseDto>>(
            HttpStatusCode.OK,
            "Courses retrieved successfully",
            coursesDto
        );
    }

    public async Task<ApiResponse<CourseByIdDto?>> GetCourse(int id)
    {
        if (id <= 0)
            return new ApiResponse<CourseByIdDto?>(
            HttpStatusCode.BadRequest, "Invalid course id", null);
        var result = await _repository.GetCourse(id);
        if (result == null)
            return new ApiResponse<CourseByIdDto?>(
                HttpStatusCode.NotFound, "Course not found", null);
        var courseDto = new CourseByIdDto
        {
            Id = result.CourseId,
            Title = result.Title,
            Description = result.Description,
            Durationweek = result.Durationweek
        };
        return new ApiResponse<CourseByIdDto?>(
            HttpStatusCode.OK, "Course retrieved successfully", courseDto);
    }   
    public async Task<ApiResponse<bool>> AddCourse(CreateCourseDto courseDto)
    {
        var course = new Course
        {
            Title = courseDto.Title,
            Description = courseDto.Description,
            Durationweek = courseDto.Durationweek
        };
        if (course == null || string.IsNullOrWhiteSpace(course.Title) || string.IsNullOrWhiteSpace(course.Description))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid course data", false);
        await _repository.AddCourse(course);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Course added successfully", true);
    }

    public async Task<ApiResponse<bool>> UpdateCourse(int id, UpdateCourseDto courseDto)
    {
        var course = new Course
        {
            Title = courseDto.Title,
            Description = courseDto.Description,
            Durationweek = courseDto.Durationweek
        };
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
