using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.CourseDtos;
using Application.DTOs.CourseByIdDtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController(ICourseService courseService) : ControllerBase
{
    private readonly ICourseService _service = courseService;

    [HttpGet]
    public async Task<ApiResponse<List<CourseDto>>> GetCourses() 
    {
        return await _service.GetCourses();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CourseByIdDto?>> GetCourse(int id)
    {
        return await _service.GetCourse(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCourse(CreateCourseDto courseDto) 
    {
        return await _service.AddCourse(courseDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateCourse(int id, UpdateCourseDto courseDto) 
    {
        return await _service.UpdateCourse(id, courseDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteCourse(int id) 
    {
        return await _service.DeleteCourse(id);
    }
}
