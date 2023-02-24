using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NETCore.Controllers;

[ApiController]
[Route("[controller]s")]
public abstract class ApiControllerBase : ControllerBase
{
    
}
