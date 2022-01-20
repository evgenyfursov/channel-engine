using ChannelEngineApi.BusinessLogic.Implementations;
using ChannelEngineApi.BusinessLogic.Interfaces;
using ChannelEngineApi.BusinessLogic.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace ChannelEngine.Console
{
    public class Program
    {
        private readonly IOrderService _orderService;

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            System.Console.WriteLine("Please type a command: ");

            var command = System.Console.ReadLine();

            switch (command)
            {
                case "GetOrderList":
                    host.Services.GetRequiredService<Program>().GetByStatus();
                    break;
                case "GetTopProducts":
                    host.Services.GetRequiredService<Program>().GetTopProductByStatus();
                    break;
                case "UpdateStock":
                    host.Services.GetRequiredService<Program>().UpdateStock();
                    break;
                default:
                    throw new Exception("Incorrect command");
            }
        }

        public Program(IOrderService orderService)
        {
            _orderService = orderService;
        }

        private void GetByStatus()
        {
            var orders = _orderService.GetByStatusAsync("IN_PROGRESS").Result;
            System.Console.WriteLine(JsonConvert.SerializeObject(orders));
        }
        
        private void GetTopProductByStatus()
        {
            var products = _orderService.GetTopProductByStatusAsync(5, "IN_PROGRESS").Result;
            System.Console.WriteLine(JsonConvert.SerializeObject(products));
        }
        
        private void UpdateStock()
        {
            _orderService.UpdateStockAsync(25, "IN_PROGRESS");
            System.Console.WriteLine("Product was updated.");
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddTransient<IOrderService, OrderService>();
                    services.AddTransient<IOrderWrapper, OrderWrapper>();
                    services.Configure<Settings>(settings =>
                    {
                        settings.Url = "https://api-dev.channelengine.net/api/v2/orders";
                        settings.ApiKey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
                        settings.UpdateStockUrl = "https://api-dev.channelengine.net/api/v2/offer";
                    });
                });
        }
    }
}