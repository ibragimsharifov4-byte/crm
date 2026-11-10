using System.Net;
using Application.DTOs.StudentByIdDtos;
using Application.DTOs.StudentDtos;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private readonly IStudentRepository _studentRepository = studentRepository;

    public async Task<ApiResponse<List<StudentDto>>> GetStudents()
    {
        var students = await _studentRepository.GetStudents();

        var studentsDto = new List<StudentDto>();

        foreach (var s in students)
        {
            var studentDto = new StudentDto
            {
                Id = s.StudentId,
                Fullname = s.Fullname,
                Email = s.Email,
                Phone = s.Phone,
                Enrollmentdate = s.Enrollmentdate
            };

            studentsDto.Add(studentDto);
        }

        return new ApiResponse<List<StudentDto>>(
            HttpStatusCode.OK, "Students retrieved successfully", studentsDto);
    }

    public async Task<ApiResponse<StudentByIdDto?>> GetStudent(int id)
    {
        if (id <= 0)
            return new ApiResponse<StudentByIdDto?>(
                HttpStatusCode.BadRequest, "Invalid student id", null);

        var student = await _studentRepository.GetStudent(id);

        if (student == null)
            return new ApiResponse<StudentByIdDto?>(
                HttpStatusCode.NotFound, "Student not found", null);

        var studentDto = new StudentByIdDto
        {
            Id = student.StudentId,
            Fullname = student.Fullname,
            Email = student.Email,
            Phone = student.Phone,
            Enrollmentdate = student.Enrollmentdate
        };

        return new ApiResponse<StudentByIdDto?>(
            HttpStatusCode.OK, "Student retrieved successfully", studentDto);
    }

    public async Task<ApiResponse<bool>> AddStudent(CreateStudentDto studentDto)
    {
        var student = new Student
        {
            Fullname = studentDto.Fullname,
            Email = studentDto.Email,
            Phone = studentDto.Phone,
            Enrollmentdate = studentDto.Enrollmentdate
        };

        if (student == null || string.IsNullOrWhiteSpace(student.Fullname) ||
            string.IsNullOrWhiteSpace(student.Email) || string.IsNullOrWhiteSpace(student.Phone))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid student data", false);

        await _studentRepository.AddStudent(student);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Student added successfully", true);
    }

    public async Task<ApiResponse<bool>> UpdateStudent(int id, UpdateStudentDto studentDto)
    {
        var student = new Student
        {
            Fullname = studentDto.Fullname,
            Email = studentDto.Email,
            Phone = studentDto.Phone,
            Enrollmentdate = studentDto.Enrollmentdate
        };

        if (id <= 0 || student == null || string.IsNullOrWhiteSpace(student.Fullname) ||
            string.IsNullOrWhiteSpace(student.Email) || string.IsNullOrWhiteSpace(student.Phone))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid student data", false);

        var oldStudent = await _studentRepository.GetStudent(id);
        if (oldStudent == null)
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Student not found", false);

        student.StudentId = id;
        await _studentRepository.UpdateStudent(student);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Student updated successfully", true);
    }

    public async Task<ApiResponse<bool>> DeleteStudent(int id)
    {
        if (id <= 0)
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid student id", false);

        var student = await _studentRepository.GetStudent(id);
        if (student == null)
            return new ApiResponse<bool>(HttpStatusCode.NotFound, "Student not found", false);

        await _studentRepository.DeleteStudent(id);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Student deleted successfully", true);
    }
}
