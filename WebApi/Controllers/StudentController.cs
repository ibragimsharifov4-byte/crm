using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _service = studentService;

    [HttpGet]
    public async Task<ApiResponse<List<Student>>> GetStudents() => await _service.GetStudents();

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Student?>> GetStudent(int id) => await _service.GetStudent(id);

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudent(Student student) => await _service.AddStudent(student);

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateStudent(int id, Student student) => await _service.UpdateStudent(id, student);

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteStudent(int id) => await _service.DeleteStudent(id);
}
