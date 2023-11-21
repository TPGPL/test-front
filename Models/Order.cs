using System.Text.Json.Serialization;

namespace OrderManagement.Models;

public class Order
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("clientId")]
    public int ClientId { get; set; }
    [JsonPropertyName("status")]
    public OrderStatus Status { get; set; }
    [JsonPropertyName("lines")]
    public List<OrderLine> Lines { get; set; }
}
