using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class MentorService(IMentorRepository mentorRepository) : IMentorService
{
    private readonly IMentorRepository _repository = mentorRepository;

    public async Task<ApiResponse<List<Mentor>>> GetMentors()
    {
        var result = await _repository.GetMentors();
        return new ApiResponse<List<Mentor>>(HttpStatusCode.OK, "Mentors retrieved successfully", result);
    }

    public async Task<ApiResponse<Mentor?>> GetMentor(int id)
    {
        if (id <= 0)
            return new ApiResponse<Mentor?>(HttpStatusCode.BadRequest, "Invalid mentor id", null);

        var result = await _repository.GetMentor(id);
        return result != null
            ? new ApiResponse<Mentor?>(HttpStatusCode.OK, "Mentor retrieved successfully", result)
            : new ApiResponse<Mentor?>(HttpStatusCode.NotFound, "Mentor not found", null);
    }

    public async Task<ApiResponse<bool>> AddMentor(Mentor mentor)
    {
        if (mentor == null || string.IsNullOrWhiteSpace(mentor.Fullname) ||
            string.IsNullOrWhiteSpace(mentor.Email) || string.IsNullOrWhiteSpace(mentor.Phone) ||
            string.IsNullOrWhiteSpace(mentor.Specialization))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid mentor data", false);

        await _repository.AddMentor(mentor);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Mentor added successfully", true);
    }

    public async Task<ApiResponse<bool>> UpdateMentor(int id, Mentor mentor)
    {
        if (id <= 0 || mentor == null || string.IsNullOrWhiteSpace(mentor.Fullname) ||
            string.IsNullOrWhiteSpace(mentor.Email) || string.IsNullOrWhiteSpace(mentor.Phone) ||
            string.IsNullOrWhiteSpace(mentor.Specialization))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid mentor data", false);

        if (await _repository.GetMentor(id) == null)
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Mentor not found", false);

        mentor.MentorId = id;
        await _repository.UpdateMentor(mentor);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Mentor updated successfully", true);
    }

    public async Task<ApiResponse<bool>> DeleteMentor(int id)
    {
        if (id <= 0)
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid mentor id", false);

        if (await _repository.GetMentor(id) == null)
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Mentor not found", false);

        await _repository.DeleteMentor(id);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Mentor deleted successfully", true);
    }
}
