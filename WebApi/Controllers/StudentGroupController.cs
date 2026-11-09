using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupController(IStudentGroupService studentGroupService) : ControllerBase
{
    private readonly IStudentGroupService _service = studentGroupService;

    [HttpGet]
    public async Task<ApiResponse<List<StudentGroup>>> GetStudentGroups() => await _service.GetStudentGroups();

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudentGroup(StudentGroup studentGroup) => await _service.AddStudentGroup(studentGroup);

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateStudentGroup(StudentGroup studentGroup) => await _service.UpdateStudentGroup(studentGroup);

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteStudentGroup(int id) => await _service.DeleteStudentGroup(id);
}
