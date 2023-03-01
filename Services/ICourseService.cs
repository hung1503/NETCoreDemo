using NETCore.Models;
using NETCore.DTOs;

namespace NETCore.Services;

public interface ICourseService : ICrudService<Course, CourseDTO>
{
    ICollection<Course> GetOngoingCourses();
    ICollection<Course> GetEndedCourses();
    ICollection<Course> GetCoursesByStatus(Course.CourseStatus status);
}