using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentGroupRepository
{
    Task<bool> AddStudentGroup(StudentGroup studentGroup);
    Task<bool> DeleteStudentGroup(int id);
    Task<bool> UpdateStudentGroup(StudentGroup studentGroup);
    Task<List<StudentGroup>> GetStudentGroups();
}
