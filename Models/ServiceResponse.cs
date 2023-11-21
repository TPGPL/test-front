using System.Text.Json.Serialization;

namespace OrderManagementApp.Models;

public class ServiceResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    [JsonPropertyName("success")]
    public bool Success { get; set; }
}
