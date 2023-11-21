using OrderManagementApp.Models;

namespace OrderManagementApp.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task CancelOrderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task CompleteOrderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<Order>> CreateOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<Order>> GetOrderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<Order>>> GetOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task SubmitOrderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<Order>> UpdateOrderAsync(int id, Order order)
    {
        throw new NotImplementedException();
    }
}
