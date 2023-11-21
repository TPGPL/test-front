using OrderManagementApp.Models;
using System.Net.Http.Json;

namespace OrderManagementApp.Services;

public class ClientService : IClientService
{
    private HttpClient _httpClient;

    public ClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ServiceResponse<List<Client>>> GetClientsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("clients");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<Client>>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Client>>>()
                ?? new ServiceResponse<List<Client>>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<Client>>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occured."
            };
        }
    }

    public async Task<ServiceResponse<Client>> GetClientAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"clients/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<Client>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Client>>()
                ?? new ServiceResponse<Client>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Client>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Client>> UpdateClientAsync(int id, Client client)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"clients/{id}", client);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Client>>()
                ?? new ServiceResponse<Client>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Client>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Client>> CreateClientAsync(Client client)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"clients", client);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Client>>()
                ?? new ServiceResponse<Client>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Client>
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task DeleteClientAsync(int id)
    {
        try
        {
            await _httpClient.DeleteAsync($"clients/{id}");
        } catch (Exception)
        {
        }
    }
}
