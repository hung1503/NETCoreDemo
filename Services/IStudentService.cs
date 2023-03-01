namespace NETCore.Services;
using NETCore.Models;
using NETCore.DTOs;


public interface IStudentService
{
    ICollection<Student> GetTopStudents();
    ICollection<Student> GetStudentsWithJobs();

}