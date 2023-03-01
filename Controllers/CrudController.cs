namespace NETCore.Controllers;

using NETCore.Services;
using NETCore.DTOs;
using NETCore.Models;
using Microsoft.AspNetCore.Mvc;

public class CrudController<TModel, TDto> : ApiControllerBase
    where TModel : BaseModel, new()
    where TDto : BaseDTO<TModel>
{
    private readonly ICrudService<TModel, TDto> _service;

    public CrudController( ICrudService<TModel, TDto> service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    public virtual IActionResult Create(TDto request)
    {
        var item = _service.Create(request);
        if(item is null)
        {
            return BadRequest("item not created");
        }
        return Ok(_service.Create(request));
    }

    [HttpGet("{id:int}")]
    public virtual ActionResult<TModel?> Get(int id)
    {
        var item = _service.Get(id);
        if(item is null)
        {
            return NotFound("item not found");
        }
        return item;
    }

    [HttpPut("{id:int}")]
    public virtual ActionResult<TModel?> Update(int id, TDto request)
    {
        var item = _service.Update(id, request);
        if(item is null)
        {
            return NotFound("item not found");
        }
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public virtual ActionResult Delete(int id)
    {
        if(_service.Delete(id))
        {
            return Ok(new { Message = "Item not deleted"});
        }
        return NotFound("Item not found");
    }

    [HttpGet]
    public virtual ICollection<TModel> GetAll()
    {
        return _service.GetAll();
    }


}