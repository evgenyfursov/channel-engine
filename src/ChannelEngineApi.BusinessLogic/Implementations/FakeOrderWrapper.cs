using ChannelEngineApi.BusinessLogic.Interfaces;
using ChannelEngineApi.BusinessLogic.Models;

namespace ChannelEngineApi.BusinessLogic.Implementations
{
    public class FakeOrderWrapper : IOrderWrapper
    {
        public Task<List<OrderDto>> GetByStatusAsync(string status)
        {
            return Task.FromResult(new List<OrderDto>()
            {
                new()
                {
                    Id = 1,
                    Email = "email1@e.e",
                    Status = "NEW",
                    IsBusinessOrder = true,
                    Lines = new List<Line>()
                    {
                        new() { Description = "product1", Gtin = "001", Quantity = 4 },
                        new() { Description = "product2", Gtin = "002", Quantity = 1 },
                        new() { Description = "product3", Gtin = "003", Quantity = 2 }
                    }
                },
                new()
                {
                    Id = 2,
                    Email = "email2@e.e",
                    Status = "IN_PROGRESS",
                    IsBusinessOrder = true,
                    Lines = new List<Line>()
                    {
                        new() { Description = "product1", Gtin = "001", Quantity = 4 },
                        new() { Description = "product3", Gtin = "003", Quantity = 4 },
                        new() { Description = "product5", Gtin = "005", Quantity = 7 }
                    }
                },
                new()
                {
                    Id = 3,
                    Email = "email3@e.e",
                    Status = "IN_PROGRESS",
                    IsBusinessOrder = false,
                    Lines = new List<Line>()
                    {
                        new() { Description = "product1", Gtin = "001", Quantity = 2 },
                    }
                },
                new()
                {
                    Id = 4,
                    Email = "email4@e.e",
                    Status = "NEW",
                    IsBusinessOrder = false,
                    Lines = new List<Line>()
                    {
                        new() { Description = "product3", Gtin = "003", Quantity = 1 },
                        new() { Description = "product4", Gtin = "004", Quantity = 1 },
                        new() { Description = "product5", Gtin = "005", Quantity = 1 }
                    }
                },
                new()
                {
                    Id = 5,
                    Email = "email5@e.e",
                    Status = "NEW",
                    IsBusinessOrder = true,
                    Lines = new List<Line>()
                    {
                        new() { Description = "product1", Gtin = "001", Quantity = 3 },
                        new() { Description = "product3", Gtin = "003", Quantity = 1 },
                    }
                },
                new()
                {
                    Id = 6,
                    Email = "email6@e.e",
                    Status = "IN_PROGRESS",
                    IsBusinessOrder = true,
                    Lines = new List<Line>()
                    {
                        new() { Description = "product3", Gtin = "003", Quantity = 6 },
                    }
                },
                new()
                {
                    Id = 7,
                    Email = "email7@e.e",
                    Status = "IN_PROGRESS",
                    IsBusinessOrder = false,
                    Lines = new List<Line>()
                    {
                        new() { Description = "product1", Gtin = "001", Quantity = 2 },
                        new() { Description = "product5", Gtin = "005", Quantity = 3 },
                        new() { Description = "product8", Gtin = "008", Quantity = 4 }
                    }
                }
            });
        }

        public Task UpdateStockAsync(int stock, string merchantProductNo)
        {
            throw new NotImplementedException();
        }
    }
}