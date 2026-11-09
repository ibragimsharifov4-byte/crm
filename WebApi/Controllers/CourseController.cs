using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController(ICourseService courseService) : ControllerBase
{
    private readonly ICourseService _service = courseService;

    [HttpGet]
    public async Task<ApiResponse<List<Course>>> GetCourses() => await _service.GetCourses();

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Course?>> GetCourse(int id) => await _service.GetCourse(id);

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCourse(Course course) => await _service.AddCourse(course);

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateCourse(int id, Course course) => await _service.UpdateCourse(id, course);

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteCourse(int id) => await _service.DeleteCourse(id);
}
