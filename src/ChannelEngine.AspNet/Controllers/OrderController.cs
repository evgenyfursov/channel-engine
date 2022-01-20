using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChannelEngine.AspNet.Models;
using ChannelEngineApi.BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;

namespace ChannelEngine.AspNet.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly ILogger<OrderController> _logger;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    public async Task<ViewResult> GetByStatusAsync()
    { 
        var inProgressOrders = await _orderService.GetByStatusAsync("IN_PROGRESS");
        
        return View(inProgressOrders);
    }
    
    public async Task<ViewResult> GetTop5ProductAsync()
    {
        var top5Product = await _orderService.GetTopProductByStatusAsync(5, "IN_PROGRESS");
        
        return View(top5Product);
    }
    
    public async Task<ViewResult> UpdateStockAsync()
    {
        await _orderService.UpdateStockAsync(25, "IN_PROGRESS");
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}