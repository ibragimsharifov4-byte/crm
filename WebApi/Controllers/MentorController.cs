using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MentorController(IMentorService mentorService) : ControllerBase
{
    private readonly IMentorService _service = mentorService;

    [HttpGet]
    public async Task<ApiResponse<List<Mentor>>> GetMentors() => await _service.GetMentors();

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Mentor?>> GetMentor(int id) => await _service.GetMentor(id);

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMentor(Mentor mentor) => await _service.AddMentor(mentor);

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateMentor(int id, Mentor mentor) => await _service.UpdateMentor(id, mentor);

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteMentor(int id) => await _service.DeleteMentor(id);
}
