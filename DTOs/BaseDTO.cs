using NETCore.Models;

namespace NETCore.DTOs;

public abstract class BaseDTO<TModel> where TModel : BaseModel
{
    public abstract void UpdateModel(TModel model);
}