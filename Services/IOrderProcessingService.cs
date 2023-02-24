using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETCore.Models;

namespace NETCore.Services;

public interface IOrderProcessingService
{
    bool ProcessOrder(Order order);
}
