using ChannelEngineApi.BusinessLogic.Interfaces;
using ChannelEngineApi.BusinessLogic.Models;

namespace ChannelEngineApi.BusinessLogic.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderWrapper _orderWrapper;

        public OrderService(IOrderWrapper orderWrapper)
        {
            _orderWrapper = orderWrapper;
        }

        public async Task<List<OrderDto>> GetByStatusAsync(string status)
        {
            return await _orderWrapper.GetByStatusAsync(status);
        }
        
        public async Task<List<ProductInfo>> GetTopProductByStatusAsync(int count, string status)
        {
            var orders = await _orderWrapper.GetByStatusAsync(status);

            var products = orders.SelectMany(o => o.Lines)
                .GroupBy(l => new { l.Gtin, l.Description });

            return products.Select(g => new ProductInfo
            {
                Description = g.Key.Description,
                Gtin = g.Key.Gtin,
                Count = g.Sum(l => l.Quantity)
            }).OrderByDescending(p => p.Count).Take(count).ToList();
        }
        
        public async Task UpdateStockAsync(int stock, string status)
        {
            var orders = await _orderWrapper.GetByStatusAsync(status);
            var products = orders.SelectMany(o => o.Lines);
            var product = products.FirstOrDefault();

            if (product == null)
                throw new ArgumentNullException("product not found");

            await _orderWrapper.UpdateStockAsync(stock, product.MerchantProductNo);
        }
    }
}