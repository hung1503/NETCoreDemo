namespace NETCore.Controllers;

using NETCore.Services;
using NETCore.DTOs;
using NETCore.Models;
using Microsoft.AspNetCore.Mvc;

public class CourseController : ApiControllerBase
{
    private readonly ILogger<CourseController> _logger;
    private readonly ICourseService _service;

    public CourseController(ILogger<CourseController> logger, ICourseService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    public IActionResult Create(CourseDTO request)
    {
        return Ok(_service.Create(request));
    }
    /*
    public ActionResult<Course?> Create(CourseDTO request)
    {
        return _service.Create(request);
    }

    public Course? Create(CourseDTO request)
    {
        return _service.Create(request);
    }
    */
    [HttpGet("{id:int}")]
    public ActionResult<Course?> Get(int id)
    {
        var course = _service.Get(id);
        if(course is null)
        {
            return NotFound("Course not found");
        }
        return course;
    }

    [HttpPut("{id:int}")]
    public ActionResult<Course?> Update(int id, CourseDTO request)
    {
        var course = _service.Update(id, request);
        if(course is null)
        {
            return NotFound("Course not found");
        }
        return Ok(course);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if(_service.Delete(id))
        {
            return Ok(new { Message = "Course not deleted"});
        }
        return NotFound("Course not found");
    }

    [HttpGet]
    public ICollection<Course> GetAll()
    {
        return _service.GetAll();
    }


}