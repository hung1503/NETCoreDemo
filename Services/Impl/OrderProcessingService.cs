using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETCore.Models;

namespace NETCore.Services;

public class OrderProcessingService : IOrderProcessingService
{
    private readonly IEmailSenderService _emailSender;

    public OrderProcessingService(IEmailSenderService emailSender)
    {
        _emailSender = emailSender;
    }
    
    public bool ProcessOrder(Order order)
    {
        if(HandleOrder(order))
        {
            _emailSender.SendEmail("customer@mail.com", "Order has been processed", "Your order has been processed");
        } 
        else
        {
            _emailSender.SendEmail("customer@mail.com", "Order has not been processed", "Your order has not been processed");
        }
        return true;
    }

    private bool HandleOrder(Order order)
    {
        return true;
    }
}
