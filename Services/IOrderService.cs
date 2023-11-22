using OrderManagementApp.Models;

namespace OrderManagementApp.Services;

public interface IOrderService
{
    Task<ServiceResponse<List<Order>>> GetOrdersAsync();
    Task<ServiceResponse<Order>> GetOrderAsync(int id);
    Task<ServiceResponse<Order>> CreateOrderAsync(Order order);
    Task<ServiceResponse<Order>> UpdateOrderAsync(int id, Order order);
    Task DeleteOrderAsync(int id);
    Task<ServiceResponse<Order>> CancelOrderAsync(int id);
    Task<ServiceResponse<Order>> SubmitOrderAsync(int id);
    Task<ServiceResponse<Order>> CompleteOrderAsync(int id);
}
