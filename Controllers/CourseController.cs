namespace NETCore.Controllers;

using NETCore.Services;
using NETCore.DTOs;
using NETCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

public class CourseController : CrudController<Course, CourseDTO>
{
    private readonly ICourseService _service;
    private readonly ILogger<CourseController> _logger;
    private readonly IConfiguration _config;
    private readonly IOptions<CourseSetting> _setting;

    public CourseController(ILogger<CourseController> logger, ICourseService service, IConfiguration config, IOptions<CourseSetting> setting) : base(service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _config = config;
        _setting = setting; 
        _service = service;
    }

    // [HttpPost]
    // public override IActionResult Create(CourseDTO request)
    // {
    //     if(request.Size < _setting.Value.MinSize || request.Size > _setting.Value.MaxSize)
    //     {
    //         return BadRequest( new {Message = "Course size is not valid"});
    //     } 
    //     var course = _service.Create(request);
    //     if(course is null)
    //     {
    //         return BadRequest("Course not created");
    //     }
    //     return Ok(_service.Create(request));
    // }

//     [HttpGet("ongoing")]
//    public ICollection<Course> GetOngoingCourse()
//    {
//         var courses = _service.GetCoursesByStatus(Course.CourseStatus.OnGoing);
//         return courses;
//    }

//     [HttpGet("finished")]
//    public ICollection<Course> GetEndedCourse()
//    {
//         var courses = _service.GetCoursesByStatus(Course.CourseStatus.Ended);
//         return courses;
//    }

   [HttpGet]
    public ICollection<Course> GetCoursesByStatus([FromQuery] Course.CourseStatus status)
   {
        var courses = _service.GetCoursesByStatus(status);
        return courses;
   }
}