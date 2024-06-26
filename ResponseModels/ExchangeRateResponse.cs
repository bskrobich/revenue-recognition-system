using System.Text.Json.Serialization;

namespace RevenueRecognitionSystem.ResponseModels;

public class ExchangeRateResponse
{
    [JsonPropertyName("conversion_rates")]
    public Dictionary<string, decimal> Rates { get; set; }
}