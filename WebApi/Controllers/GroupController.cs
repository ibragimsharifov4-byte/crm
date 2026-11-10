using Application.DTOs.GroupByIdDtos;
using Application.DTOs.GroupDtos;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController(IGroupService groupService) : ControllerBase
{
    private readonly IGroupService _service = groupService;

    [HttpGet]
    public async Task<ApiResponse<List<GroupDto>>> GetGroups() => await _service.GetGroups();

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GroupByIdDto?>> GetGroup(int id) => await _service.GetGroup(id);

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGroup(CreateGroupDto groupDto) => await _service.AddGroup(groupDto);

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateGroup(int id, UpdateGroupDto groupDto) => await _service.UpdateGroup(id, groupDto);

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteGroup(int id) => await _service.DeleteGroup(id);
}
