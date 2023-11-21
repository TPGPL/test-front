using OrderManagement.Models;

namespace OrderManagement.Services;

public interface IClientService
{
    Task<ServiceResponse<Client>> GetClientAsync(int id);
    Task<ServiceResponse<List<Client>>> GetClientsAsync();
    Task<ServiceResponse<Client>> CreateClientAsync(Client client);
    Task<ServiceResponse<Client>> UpdateClientAsync(int id, Client client);
    Task DeleteClientAsync(int id);
}
