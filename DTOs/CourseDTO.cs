namespace NETCore.DTOs;

using System.ComponentModel.DataAnnotations;
using NETCore.Models;
using NETCore.Common;

public class CourseDTO : BaseDTO<Course>, IValidatableObject 
{
    [MinLength(5, ErrorMessage = "Course name must be at least 5 characters long")]
    public string? Name { get; set; }

    [CourseStartDate(ErrorMessage = "Course start date must be in the same year")]
    public DateTime StartDate { get; set; }

    public Course.CourseStatus Status { get; set; }
    public int Size { get; set; }

    public override void UpdateModel(Course model)
    {
        model.Name = Name;
        model.StartDate = StartDate;
        model.Status = Status;
        model.Size = Size;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartDate < DateTime.Now && Status == Course.CourseStatus.NotStarted)
        {
            yield return new ValidationResult("The course is already started", new[] { nameof(StartDate) });
        }
        if (!Name!.StartsWith("FIN"))
        {
            yield return new ValidationResult("The name has to start with: FIN FS<number>", new string[]{nameof(Name)});
        }

    }
}