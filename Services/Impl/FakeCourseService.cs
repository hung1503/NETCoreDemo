using NETCore.DTOs;
using NETCore.Models;
using System.Collections.Concurrent;

namespace NETCore.Services;

public class FakeCourseService : ICourseService
{
    // private ICollection<Course> _courses = new List<Course>();
    // private Dictionary<int, Course> _courses = new();
    private ConcurrentDictionary<int, Course> _courses = new();
    private int _courseId;

    public Course? Create(CourseDTO request)
    {
        var course = new Course 
        {
            Id = Interlocked.Increment(ref _courseId), // Atomic operation
            Name = request.Name,
            StartDate = request.StartDate,
            Status = request.Status
        };
        _courses[course.Id] = course;
        return course;
    }

    public bool Delete(int id)
    {
        if(!_courses.ContainsKey(id))
        {
            return false;
        }
        return _courses.Remove(id, out var _);
    }

    public Course? Get(int id)
    {   
        if(_courses.TryGetValue(id, out var course))
        {
            return course;
        }
        return null;
    }

    public ICollection<Course> GetAll()
    {
        return _courses.Values;
    }

    public Course? Update(int id, CourseDTO request)
    {
        var course = Get(id);
        if(course is null)
        {
            return null;
        }
        course.Name = request.Name;
        course.StartDate = request.StartDate;
        course.Status = request.Status;
        return course;
    }
}