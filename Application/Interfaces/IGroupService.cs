using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IGroupService
{
    Task<ApiResponse<List<Group>>> GetGroups();
    Task<ApiResponse<Group?>> GetGroup(int id);
    Task<ApiResponse<bool>> AddGroup(Group group);
    Task<ApiResponse<bool>> UpdateGroup(int id, Group group);
    Task<ApiResponse<bool>> DeleteGroup(int id);
}
