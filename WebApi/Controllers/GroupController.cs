using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController(IGroupService groupService) : ControllerBase
{
    private readonly IGroupService _service = groupService;

    [HttpGet]
    public async Task<ApiResponse<List<Group>>> GetGroups() => await _service.GetGroups();

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Group?>> GetGroup(int id) => await _service.GetGroup(id);

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGroup(Group group) => await _service.AddGroup(group);

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateGroup(int id, Group group) => await _service.UpdateGroup(id, group);

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteGroup(int id) => await _service.DeleteGroup(id);
}
