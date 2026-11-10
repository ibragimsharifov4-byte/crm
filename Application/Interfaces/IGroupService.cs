using Application.DTOs.GroupByIdDtos;
using Application.DTOs.GroupDtos;
using Application.Responses;

namespace Application.Interfaces;

public interface IGroupService
{
    Task<ApiResponse<List<GroupDto>>> GetGroups();
    Task<ApiResponse<GroupByIdDto?>> GetGroup(int id);
    Task<ApiResponse<bool>> AddGroup(CreateGroupDto groupDto);
    Task<ApiResponse<bool>> UpdateGroup(int id, UpdateGroupDto groupDto);
    Task<ApiResponse<bool>> DeleteGroup(int id);
}
