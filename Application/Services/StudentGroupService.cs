using System.Net;
using Application.DTOs.StudentGroupDtos;
using Application.Interfaces;
using Application.Responses;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentGroupService(IStudentGroupRepository studentGroupRepository) : IStudentGroupService
{
    private readonly IStudentGroupRepository _repository = studentGroupRepository;

    public async Task<ApiResponse<List<StudentGroupDto>>> GetStudentGroups()
    {
        var result = await _repository.GetStudentGroups();

        var studentGroupsDto = new List<StudentGroupDto>();

        foreach (var sg in result)
        {
            var studentGroupDto = new StudentGroupDto
            {
                Id = sg.StudentGroupId,
                StudentId = sg.StudentId,
                GroupId = sg.GroupId,
                Status = sg.Status
            };

            studentGroupsDto.Add(studentGroupDto);
        }

        return new ApiResponse<List<StudentGroupDto>>(
            HttpStatusCode.OK, "Student groups retrieved successfully", studentGroupsDto);
    }

    public async Task<ApiResponse<bool>> AddStudentGroup(CreateStudentGroupDto studentGroupDto)
    {
        var studentGroup = new StudentGroup
        {
            StudentGroupId = studentGroupDto.StudentGroupId,
            StudentId = studentGroupDto.StudentId,
            GroupId = studentGroupDto.GroupId,
            Status = studentGroupDto.Status
        };

        if (studentGroup == null)
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid student group data", false);

        var result = await _repository.AddStudentGroup(studentGroup);
        return result
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Student group added successfully", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Failed to add student group", false);
    }

    public async Task<ApiResponse<bool>> UpdateStudentGroup(UpdateStudentGroupDto studentGroupDto)
    {
        var studentGroup = new StudentGroup
        {
            StudentGroupId = studentGroupDto.StudentGroupId,
            StudentId = studentGroupDto.StudentId,
            GroupId = studentGroupDto.GroupId,
            Status = studentGroupDto.Status
        };

        if (studentGroup == null || studentGroup.StudentGroupId <= 0)
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid student group data", false);

        var result = await _repository.UpdateStudentGroup(studentGroup);
        return result
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Student group updated successfully", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, "Student group not found", false);
    }

    public async Task<ApiResponse<bool>> DeleteStudentGroup(int id)
    {
        if (id <= 0)
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid student group id", false);

        var result = await _repository.DeleteStudentGroup(id);
        return result
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Student group deleted successfully", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, "Student group not found", false);
    }
}
