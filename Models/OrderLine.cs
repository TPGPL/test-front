﻿using System.Text.Json.Serialization;

namespace OrderManagement.Models;

public class OrderLine
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("productId")]
    public int ProductId { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}