using Application.DTOs.StudentByIdDtos;
using Application.DTOs.StudentDtos;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _service = studentService;

    [HttpGet]
    public async Task<ApiResponse<List<StudentDto>>> GetStudents() => await _service.GetStudents();

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<StudentByIdDto?>> GetStudent(int id) => await _service.GetStudent(id);

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudent(CreateStudentDto studentDto) => await _service.AddStudent(studentDto);

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateStudent(int id, UpdateStudentDto studentDto) => await _service.UpdateStudent(id, studentDto);

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteStudent(int id) => await _service.DeleteStudent(id);
}
