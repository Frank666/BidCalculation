using System.Text.Json.Serialization;

namespace BidCalculation.Abstractions.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]

public enum CarType
{
    Common,
    Luxury
}