using System.Text.Json.Serialization;

namespace OrderManagement.Models;

public class Product
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("price")]
    public double Price { get; set; }
    [JsonPropertyName("stockQuantity")]
    public int StockQuantity { get; set; }
}
