using Application.DTOs.GroupByIdDtos;
using Application.DTOs.GroupDtos;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController(IGroupService groupService, ILogger<GroupController> logger) : ControllerBase
{
    private readonly IGroupService _service = groupService;
    private readonly ILogger<GroupController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<GroupDto>>> GetGroups()
    {
        _logger.LogInformation("Geting the groups");
        return await _service.GetGroups();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GroupByIdDto?>> GetGroup(int id)
    {
        _logger.LogInformation("Get group by id");
        return await _service.GetGroup(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGroup(CreateGroupDto groupDto)
    {
        _logger.LogInformation("Adding the group");
        return await _service.AddGroup(groupDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateGroup(int id, UpdateGroupDto groupDto)
    {
        _logger.LogInformation("Update the group");
        return await _service.UpdateGroup(id, groupDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteGroup(int id)
    {
        _logger.LogInformation("Delete the group");
        return await _service.DeleteGroup(id);
    }
}
