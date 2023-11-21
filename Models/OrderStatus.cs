using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OrderManagementApp.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus
{
    [EnumMember(Value ="New")]
    New,
    [EnumMember(Value = "InProgress")]
    InProgress,
    [EnumMember(Value = "Completed")]
    Completed,
    [EnumMember(Value = "Cancelled")]
    Cancelled
}
