using System.Text.Json.Serialization;

namespace OrderManagement.Models;

public class Client
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("surname")]
    public string Surname { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("orders")]
    public List<Order> Orders { get; set; }
}
