using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private readonly IStudentRepository _studentRepository = studentRepository;

    public async Task<ApiResponse<List<Student>>> GetStudents()
    {
        var students = await _studentRepository.GetStudents();
        return new ApiResponse<List<Student>>(HttpStatusCode.OK, "Students retrieved successfully", students);
    }

    public async Task<ApiResponse<Student?>> GetStudent(int id)
    {
        if (id <= 0)
            return new ApiResponse<Student?>(HttpStatusCode.BadRequest, "Invalid student id", null);

        var student = await _studentRepository.GetStudent(id);
        return student != null
            ? new ApiResponse<Student?>(HttpStatusCode.OK, "Student retrieved successfully", student)
            : new ApiResponse<Student?>(HttpStatusCode.NotFound, "Student not found", null);
    }

    public async Task<ApiResponse<bool>> AddStudent(Student student)
    {
        if (student == null || string.IsNullOrWhiteSpace(student.Fullname) ||
            string.IsNullOrWhiteSpace(student.Email) || string.IsNullOrWhiteSpace(student.Phone))
            return new ApiResponse<bool>(HttpStatusCode.BadRequest, "Invalid student data", false);

        await _studentRepository.AddStudent(student);
        return new ApiResponse<bool>(HttpStatusCode.OK, "Student added successfully", true);
    }

    public async Task<ApiResponse<bool>> UpdateStudent(int id, Student student)
    {
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
