using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.CourseDtos;
using Application.DTOs.CourseByIdDtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController(ICourseService courseService , ILogger<CourseController> logger) : ControllerBase
{
    private readonly ICourseService _service = courseService;
    private readonly ILogger<CourseController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<CourseDto>>> GetCourses() 
    {
        _logger.LogInformation("Geting the courses");
        return await _service.GetCourses();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CourseByIdDto?>> GetCourse(int id)
    {
        _logger.LogInformation("Get course by id");
        return await _service.GetCourse(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCourse(CreateCourseDto courseDto) 
    {
        _logger.LogInformation("Adding the course");
        return await _service.AddCourse(courseDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateCourse(int id, UpdateCourseDto courseDto) 
    {
        _logger.LogInformation("Update the course");
        return await _service.UpdateCourse(id, courseDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteCourse(int id) 
    {
        _logger.LogInformation("Delete the course");
        return await _service.DeleteCourse(id);
    }
}
