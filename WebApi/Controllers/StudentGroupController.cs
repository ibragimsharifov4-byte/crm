using Application.DTOs.StudentGroupDtos;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupController(IStudentGroupService studentGroupService, ILogger<StudentGroupController> logger) : ControllerBase
{
    private readonly IStudentGroupService _service = studentGroupService;
    private readonly ILogger<StudentGroupController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<StudentGroupDto>>> GetStudentGroups()
    {
        _logger.LogInformation("Geting the student groups");
        return await _service.GetStudentGroups();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddStudentGroup(CreateStudentGroupDto studentGroupDto)
    {
        _logger.LogInformation("Adding the student group");
        return await _service.AddStudentGroup(studentGroupDto);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateStudentGroup(UpdateStudentGroupDto studentGroupDto)
    {
        _logger.LogInformation("Update the student group");
        return await _service.UpdateStudentGroup(studentGroupDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteStudentGroup(int id)
    {
        _logger.LogInformation("Delete the student group");
        return await _service.DeleteStudentGroup(id);
    }
}
