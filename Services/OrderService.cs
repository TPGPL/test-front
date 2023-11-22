using OrderManagementApp.Models;
using System.Net.Http.Json;

namespace OrderManagementApp.Services;

public class OrderService : IOrderService
{
    private HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ServiceResponse<List<Order>>> GetOrdersAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("orders");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<Order>>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Order>>>()
                ?? new ServiceResponse<List<Order>>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<Order>>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occured."
            };
        }
    }

    public async Task<ServiceResponse<Order>> GetOrderAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"orders/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<Order>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Order>>()
                ?? new ServiceResponse<Order>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Order>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Order>> UpdateOrderAsync(int id, Order order)
    {
        try
        {
            var response = await _httpClient.PatchAsJsonAsync($"orders/{id}", order);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Order>>()
                ?? new ServiceResponse<Order>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Order>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Order>> CreateOrderAsync(Order order)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"orders", order);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Order>>()
                ?? new ServiceResponse<Order>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Order>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task DeleteOrderAsync(int id)
    {
        try
        {
            await _httpClient.DeleteAsync($"orders/{id}");
        }
        catch (Exception)
        {
        }
    }

    public async Task<ServiceResponse<Order>> CancelOrderAsync(int id)
    {
        try
        {
            var response = await _httpClient.PutAsync($"orders/{id}/cancel", null);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Order>>()
                ?? new ServiceResponse<Order>() { Success = false, Message = "Failed to read data." };

            return result;

        } catch (Exception e)
        {
            return new ServiceResponse<Order>
            {
                Success = false,
                Message = e.Message ?? "Failed to cancel the order."
            };
        }
    }

    public async Task<ServiceResponse<Order>> CompleteOrderAsync(int id)
    {
        try
        {
            var response = await _httpClient.PutAsync($"orders/{id}/complete", null);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Order>>()
                ?? new ServiceResponse<Order>() { Success = false, Message = "Failed to read data." };

            return result;

        }
        catch (Exception e)
        {
            return new ServiceResponse<Order>
            {
                Success = false,
                Message = e.Message ?? "Failed to complete the order."
            };
        }
    }

    public async Task<ServiceResponse<Order>> SubmitOrderAsync(int id)
    {
        try
        {
            var response = await _httpClient.PutAsync($"orders/{id}/submit", null);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Order>>()
                ?? new ServiceResponse<Order>() { Success = false, Message = "Failed to read data." };

            return result;

        }
        catch (Exception e)
        {
            return new ServiceResponse<Order>
            {
                Success = false,
                Message = e.Message ?? "Failed to submit the order."
            };
        }
    }
}
