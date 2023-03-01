using NETCore.DTOs;
using NETCore.Models;
using System.Collections.Concurrent;

namespace NETCore.Services;

public class FakeStudentService : FakeCrudService<Student, StudentDTO>, IStudentService
{
    public ICollection<Student> GetStudentsWithJobs()
    {
        throw new NotImplementedException();
    }

    public ICollection<Student> GetTopStudents()
    {
        throw new NotImplementedException();
    }
}