using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GroupService(IGroupRepository groupRepository) : IGroupService
{
    private readonly IGroupRepository _repository = groupRepository;

    public async Task<ApiResponse<List<Group>>> GetGroups()
    {
        var result = await _repository.GetGroups();
        return new ApiResponse<List<Group>>(HttpStatusCode.OK, "Groups retrieved successfully", result);
    }

    public async Task<ApiResponse<Group?>> GetGroup(int id)
    {
        if (id <= 0)
            return new ApiResponse<Group?>(HttpStatusCode.BadRequest, "Invalid group id", null);

        var result = await _repository.GetGroup(id);
        return result != null
            ? new ApiResponse<Group?>(HttpStatusCode.OK, "Group retrieved successfully", result)
            : new ApiResponse<Group?>(HttpStatusCode.NotFound, "Group not found", null);
    }

    public async Task<ApiResponse<bool>> AddGroup(Group group)
    {
        if (group == null || string.IsNullOrWhiteSpace(group.GroupName))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid group data", false);

        await _repository.AddGroup(group);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Group added successfully", true);
    }

    public async Task<ApiResponse<bool>> UpdateGroup(int id, Group group)
    {
        if (id <= 0 || group == null || string.IsNullOrWhiteSpace(group.GroupName))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid group data", false);

        if (await _repository.GetGroup(id) == null)
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Group not found", false);

        group.GroupId = id;
        await _repository.UpdateGroup(group);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Group updated successfully", true);
    }

    public async Task<ApiResponse<bool>> DeleteGroup(int id)
    {
        if (id <= 0)
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid group id", false);

        if (await _repository.GetGroup(id) == null)
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Group not found", false);

        await _repository.DeleteGroup(id);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Group deleted successfully", true);
    }
}
