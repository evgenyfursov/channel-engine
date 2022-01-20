using ChannelEngineApi.BusinessLogic.Models;

namespace ChannelEngineApi.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetByStatusAsync(string status);

        Task<List<ProductInfo>> GetTopProductByStatusAsync(int count, string status);

        Task UpdateStockAsync(int stock, string status);
    }
}
