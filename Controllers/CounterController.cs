using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NETCore.Models;
using NETCore.Services;

namespace NETCore.Controllers;

public class CounterController : ApiControllerBase
{

    private readonly ILogger<CounterController> _logger;
    private readonly ICounterService _counterService;

    public CounterController(ILogger<CounterController> logger, ICounterService counterService)
    {
        _logger = logger;
        _counterService = counterService;
    }

    [HttpGet]
    public IActionResult GetCounter()
    {
        return Ok(new{counterValue = _counterService.CurrentValue});
    }
}
