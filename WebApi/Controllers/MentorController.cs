using Application.DTOs.MentorByIdDtos;
using Application.DTOs.MentorDtos;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MentorController(IMentorService mentorService, ILogger<MentorController> logger) : ControllerBase
{
    private readonly IMentorService _service = mentorService;
    private readonly ILogger<MentorController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<MentorDto>>> GetMentors()
    {
        _logger.LogInformation("Geting the mentors");
        return await _service.GetMentors();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<MentorByIdDto?>> GetMentor(int id)
    {
        _logger.LogInformation("Get mentor by id");
        return await _service.GetMentor(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMentor(CreateMentorDto mentorDto)
    {
        _logger.LogInformation("Adding the mentor");
        return await _service.AddMentor(mentorDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateMentor(int id, UpdateMentorDto mentorDto)
    {
        _logger.LogInformation("Update the mentor");
        return await _service.UpdateMentor(id, mentorDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteMentor(int id)
    {
        _logger.LogInformation("Delete the mentor");
        return await _service.DeleteMentor(id);
    }
}
