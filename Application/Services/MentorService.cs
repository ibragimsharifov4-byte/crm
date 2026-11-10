using System.Net;
using Application.DTOs.MentorByIdDtos;
using Application.DTOs.MentorDtos;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class MentorService(IMentorRepository mentorRepository) : IMentorService
{
    private readonly IMentorRepository _repository = mentorRepository;

    public async Task<ApiResponse<List<MentorDto>>> GetMentors()
    {
        var result = await _repository.GetMentors();

        var mentorsDto = new List<MentorDto>();

        foreach (var m in result)
        {
            var mentorDto = new MentorDto
            {
                Id = m.MentorId,
                Fullname = m.Fullname,
                Email = m.Email,
                Phone = m.Phone,
                Specialization = m.Specialization
            };

            mentorsDto.Add(mentorDto);
        }

        return new ApiResponse<List<MentorDto>>(
            HttpStatusCode.OK, "Mentors retrieved successfully", mentorsDto);
    }

    public async Task<ApiResponse<MentorByIdDto?>> GetMentor(int id)
    {
        if (id <= 0)
            return new ApiResponse<MentorByIdDto?>(
                HttpStatusCode.BadRequest, "Invalid mentor id", null);

        var result = await _repository.GetMentor(id);

        if (result == null)
            return new ApiResponse<MentorByIdDto?>(
                HttpStatusCode.NotFound, "Mentor not found", null);

        var mentorDto = new MentorByIdDto
        {
            Id = result.MentorId,
            Fullname = result.Fullname,
            Email = result.Email,
            Phone = result.Phone,
            Specialization = result.Specialization
        };

        return new ApiResponse<MentorByIdDto?>(
            HttpStatusCode.OK, "Mentor retrieved successfully", mentorDto);
    }

    public async Task<ApiResponse<bool>> AddMentor(CreateMentorDto mentorDto)
    {
        var mentor = new Mentor
        {
            Fullname = mentorDto.Fullname,
            Email = mentorDto.Email,
            Phone = mentorDto.Phone,
            Specialization = mentorDto.Specialization
        };

        if (mentor == null || string.IsNullOrWhiteSpace(mentor.Fullname) ||
            string.IsNullOrWhiteSpace(mentor.Email) || string.IsNullOrWhiteSpace(mentor.Phone) ||
            string.IsNullOrWhiteSpace(mentor.Specialization))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid mentor data", false);

        await _repository.AddMentor(mentor);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Mentor added successfully", true);
    }

    public async Task<ApiResponse<bool>> UpdateMentor(int id, UpdateMentorDto mentorDto)
    {
        var mentor = new Mentor
        {
            Fullname = mentorDto.Fullname,
            Email = mentorDto.Email,
            Phone = mentorDto.Phone,
            Specialization = mentorDto.Specialization
        };

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
