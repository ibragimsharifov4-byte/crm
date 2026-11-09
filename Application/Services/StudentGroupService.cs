using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentGroupService(IStudentGroupRepository studentGroupRepository) : IStudentGroupService
{
    private readonly IStudentGroupRepository _repository = studentGroupRepository;

    public async Task<ApiResponse<List<StudentGroup>>> GetStudentGroups()
    {
        var result = await _repository.GetStudentGroups();
        return new ApiResponse<List<StudentGroup>>(HttpStatusCode.OK, "Student groups retrieved successfully", result);
    }

    public async Task<ApiResponse<bool>> AddStudentGroup(StudentGroup studentGroup)
    {
        if (studentGroup == null)
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid student group data", false);

        var result = await _repository.AddStudentGroup(studentGroup);
        return result
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Student group added successfully", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Failed to add student group", false);
    }

    public async Task<ApiResponse<bool>> UpdateStudentGroup(StudentGroup studentGroup)
    {
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
