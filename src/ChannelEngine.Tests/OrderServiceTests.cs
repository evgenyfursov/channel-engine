using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelEngineApi.BusinessLogic.Implementations;
using ChannelEngineApi.BusinessLogic.Models;
using FluentAssertions;
using NUnit.Framework;

namespace ChannelEngine.Tests;

public class OrderServiceTests
{
    private readonly OrderService _orderService;

    public OrderServiceTests()
    {
        _orderService = new OrderService(new FakeOrderWrapper());
    }

    [Test]
    public async Task OrderService_GetTopProducts_Ok()
    {
        var expected = _productInfos;
            
        var actual = await _orderService.GetTopProductByStatusAsync(5, "IN_PROGRESS");

        Assert.AreEqual(actual.Count, expected.Count);
        actual.Should().BeEquivalentTo(expected);
    }

    private readonly List<ProductInfo> _productInfos = new()
    {
        new() { Description = "product1", Gtin = "001", Count = 15 },
        new() { Description = "product3", Gtin = "003", Count = 14 },
        new() { Description = "product5", Gtin = "005", Count = 11 },
        new() { Description = "product8", Gtin = "008", Count = 4 },
        new() { Description = "product2", Gtin = "002", Count = 1 },
    };
}