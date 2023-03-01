namespace NETCore.Controllers;

using NETCore.DTOs;
using NETCore.Models;
using NETCore.Services;

public class StudentController : CrudController<Student, StudentDTO>
{
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger, ICrudService<Student, StudentDTO> service) : base(service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

}