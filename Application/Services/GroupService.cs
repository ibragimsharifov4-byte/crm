using System.Net;
using Application.DTOs.GroupByIdDtos;
using Application.DTOs.GroupDtos;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GroupService(IGroupRepository groupRepository) : IGroupService
{
    private readonly IGroupRepository _repository = groupRepository;

    public async Task<ApiResponse<List<GroupDto>>> GetGroups()
    {
        var result = await _repository.GetGroups();

        var groupsDto = new List<GroupDto>();

        foreach (var g in result)
        {
            var groupDto = new GroupDto
            {
                Id = g.GroupId,
                GroupName = g.GroupName,
                CourseId = g.CourseId,
                MentorId = g.MentorId,
                StartDate = g.StartDate,
                EndDate = g.EndDate
            };

            groupsDto.Add(groupDto);
        }

        return new ApiResponse<List<GroupDto>>(
            HttpStatusCode.OK, "Groups retrieved successfully", groupsDto);
    }

    public async Task<ApiResponse<GroupByIdDto?>> GetGroup(int id)
    {
        if (id <= 0)
            return new ApiResponse<GroupByIdDto?>(
                HttpStatusCode.BadRequest, "Invalid group id", null);

        var result = await _repository.GetGroup(id);

        if (result == null)
            return new ApiResponse<GroupByIdDto?>(
                HttpStatusCode.NotFound, "Group not found", null);

        var groupDto = new GroupByIdDto
        {
            Id = result.GroupId,
            GroupName = result.GroupName,
            CourseId = result.CourseId,
            MentorId = result.MentorId,
            StartDate = result.StartDate,
            EndDate = result.EndDate
        };

        return new ApiResponse<GroupByIdDto?>(
            HttpStatusCode.OK, "Group retrieved successfully", groupDto);
    }

    public async Task<ApiResponse<bool>> AddGroup(CreateGroupDto groupDto)
    {
        var group = new Group
        {
            GroupName = groupDto.GroupName,
            CourseId = groupDto.CourseId,
            MentorId = groupDto.MentorId,
            StartDate = groupDto.StartDate,
            EndDate = groupDto.EndDate
        };

        if (group == null || string.IsNullOrWhiteSpace(group.GroupName))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid group data", false);

        await _repository.AddGroup(group);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Group added successfully", true);
    }

    public async Task<ApiResponse<bool>> UpdateGroup(int id, UpdateGroupDto groupDto)
    {
        var group = new Group
        {
            GroupName = groupDto.GroupName,
            CourseId = groupDto.CourseId,
            MentorId = groupDto.MentorId,
            StartDate = groupDto.StartDate,
            EndDate = groupDto.EndDate
        };

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
