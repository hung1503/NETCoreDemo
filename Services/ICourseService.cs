using NETCore.Models;
using NETCore.DTOs;

namespace NETCore.Services;

public interface ICourseService
{
    // CRUD Operations
    Course? Create(CourseDTO request);
    Course? Get(int id);
    Course? Update(int id, CourseDTO request);
    bool Delete(int id);
    ICollection<Course> GetAll();
}