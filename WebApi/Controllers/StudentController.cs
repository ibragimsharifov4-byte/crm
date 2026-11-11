using Application.DTOs.StudentByIdDtos;
using Application.DTOs.StudentDtos;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService, ILogger<StudentController> logger) : ControllerBase
{
    private readonly IStudentService _service = studentService;
    private readonly ILogger<StudentController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<StudentDto>>> GetStudents()
    {
        _logger.LogInformation("Geting the students");
        return await _service.GetStudents();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<StudentByIdDto?>> GetStudent(int id)
    {
        _logger.LogInformation("Get student by id");
        return await _service.GetStudent(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudent(CreateStudentDto studentDto)
    {
        _logger.LogInformation("Adding the student");
        return await _service.AddStudent(studentDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateStudent(int id, UpdateStudentDto studentDto)
    {
        _logger.LogInformation("Update the student");
        return await _service.UpdateStudent(id, studentDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteStudent(int id)
    {
        _logger.LogInformation("Delete the student");
        return await _service.DeleteStudent(id);
    }
}
