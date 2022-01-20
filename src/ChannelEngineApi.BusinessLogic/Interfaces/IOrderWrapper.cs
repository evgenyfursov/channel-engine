using ChannelEngineApi.BusinessLogic.Models;

namespace ChannelEngineApi.BusinessLogic.Interfaces
{
    public interface IOrderWrapper
    {
        Task<List<OrderDto>> GetByStatusAsync(string status);

        Task UpdateStockAsync(int stock, string merchantProductNo);
    }
}
