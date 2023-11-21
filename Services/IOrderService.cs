using OrderManagement.Models;

namespace OrderManagement.Services;

public interface IOrderService
{
    Task<ServiceResponse<List<Order>>> GetOrdersAsync();
    Task<ServiceResponse<Order>> GetOrderAsync(int id);
    Task<ServiceResponse<Order>> CreateOrderAsync(Order order);
    Task<ServiceResponse<Order>> UpdateOrderAsync(int id, Order order);
    Task DeleteOrderAsync(int id);
    Task CancelOrderAsync(int id);
    Task SubmitOrderAsync(int id);
    Task CompleteOrderAsync(int id);
}
