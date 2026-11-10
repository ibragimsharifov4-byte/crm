using Application.DTOs.MentorByIdDtos;
using Application.DTOs.MentorDtos;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MentorController(IMentorService mentorService) : ControllerBase
{
    private readonly IMentorService _service = mentorService;

    [HttpGet]
    public async Task<ApiResponse<List<MentorDto>>> GetMentors() => await _service.GetMentors();

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<MentorByIdDto?>> GetMentor(int id) => await _service.GetMentor(id);

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMentor(CreateMentorDto mentorDto) => await _service.AddMentor(mentorDto);

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateMentor(int id, UpdateMentorDto mentorDto) => await _service.UpdateMentor(id, mentorDto);

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteMentor(int id) => await _service.DeleteMentor(id);
}
