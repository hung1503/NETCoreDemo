namespace NETCore.DTOs;

using NETCore.Models;

public class AssignmentDTO : BaseDTO<Assignment>
{
    public DateTime Deadline { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public override void UpdateModel(Assignment model)
    {
        model.Deadline = Deadline;
        model.Name = Name;
        model.Description = Description;
    }
}