using Application.DTOs.StudentGroupDtos;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupController(IStudentGroupService studentGroupService) : ControllerBase
{
    private readonly IStudentGroupService _service = studentGroupService;

    [HttpGet]
    public async Task<ApiResponse<List<StudentGroupDto>>> GetStudentGroups() => await _service.GetStudentGroups();

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudentGroup(CreateStudentGroupDto studentGroupDto) => await _service.AddStudentGroup(studentGroupDto);

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateStudentGroup(UpdateStudentGroupDto studentGroupDto) => await _service.UpdateStudentGroup(studentGroupDto);

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteStudentGroup(int id) => await _service.DeleteStudentGroup(id);
}
