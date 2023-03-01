using System.ComponentModel.DataAnnotations;
namespace NETCore.Common;

public class CourseSizeAttribute : ValidationAttribute 
{
    private readonly IConfiguration _config;

    public CourseSizeAttribute(IConfiguration config)
    {
        _config = config;
    }

    public override bool IsValid(object? value)
    {
        if(value is null) 
        {
            return false;
        }
        var size = (int)value;
        var minSize = _config.GetValue<int>("Course:Batch:MinSize");
        return size >= minSize; 
    }
}