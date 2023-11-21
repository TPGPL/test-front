using OrderManagementApp.Models;
using System.Net.Http.Json;

namespace OrderManagementApp.Services;

public class ProductService : IProductService
{
    private HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("products");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<Product>>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Product>>>()
                ?? new ServiceResponse<List<Product>>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<Product>>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occured."
            };
        }
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"products/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<Product>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Product>>()
                ?? new ServiceResponse<Product>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Product>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Product>> UpdateProductAsync(int id, Product product)
    {
        try
        {
            var response = await _httpClient.PatchAsJsonAsync($"products/{id}", product);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Product>>()
                ?? new ServiceResponse<Product>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Product>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Product>> CreateProductAsync(Product product)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"products", product);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Product>>()
                ?? new ServiceResponse<Product>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Product>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task DeleteProductAsync(int id)
    {
        try
        {
            await _httpClient.DeleteAsync($"products/{id}");
        } catch (Exception)
        {
        }
    }
}
